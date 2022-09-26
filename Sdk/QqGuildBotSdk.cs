using System.Net;
using System.Reflection.Emit;
using System.Xml.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QqChannelRobotSdk.Announces;
using QqChannelRobotSdk.Audio;
using QqChannelRobotSdk.Authenticate;
using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.Messages.Ark;
using QqChannelRobotSdk.Messages.Markdown;
using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.Models.Forums;
using QqChannelRobotSdk.Request;
using QqChannelRobotSdk.Response;
using QqChannelRobotSdk.Tools;

namespace QqChannelRobotSdk.Sdk;

public class QqGuildBotSdk
{
    internal QqGuildBotSdk(BotIdentifier identifier)
    {
        BotIdentifier = identifier;
    }
    public static QqGuildBotSdk GetSdk(BotIdentifier identifier)
    {
        return QqChannelBotSdkManager.GetInstance().Get(identifier);
    }
    
    public bool UseSandboxEnvironment { get; set; }
    public BotIdentifier BotIdentifier { get; private set; }
    private static readonly string FormalUrl = "https://api.sgroup.qq.com/";
    private static readonly string SandboxUrl = "https://sandbox.api.sgroup.qq.com/";
    string GetBaseUrl() => UseSandboxEnvironment
        ? SandboxUrl
        : FormalUrl;
    
    public async Task<ApiResponse<User?, GeneralErrorResponse>> GetBotInfoAsync()
    {
        HttpClient client = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        string reqUrl = GetBaseUrl() + "users/@me";
        var result = await client.GetAsync(reqUrl);
        return await ResponseTools.GetReturnValueAsync<User?>(result);
    }

    public async Task<ApiResponse<Guild[]?, GeneralErrorResponse>> GetJoinedGuildAsync(string? beforeGuild = null, string? afterGuild = null, int? limit = null)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl() + "users/@me/guilds", true);
        urlBuilder.AddArgumentWhenNotNull("before", beforeGuild)
            .AddArgumentWhenNotNull("after", afterGuild)
            .AddArgumentWhenNotNull("limit", limit);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var result = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<Guild[]?>(result);
    }

    public async Task<ApiResponse<Guild?, GeneralErrorResponse>> GetGuildInfoAsync(string guildId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel(guildId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var result = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<Guild?>(result);
    }
    
    public async Task<ApiResponse<Guild?, GeneralErrorResponse>> GetGuildInfoAsync(Guild guild) => await GetGuildInfoAsync(guild.Id);

    public async Task<ApiResponse<Channel[]?, GeneralErrorResponse>> GetChannelsAsync(string guildId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("channels");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
         var result = await httpClient.GetAsync(urlBuilder.Build());
         return await ResponseTools.GetReturnValueAsync<Channel[]>(result);
    }
    
    public async Task<ApiResponse<Channel[]?, GeneralErrorResponse>> GetChannelsAsync(Guild guild) => await GetChannelsAsync(guild.Id);

    public async Task<ApiResponse<Channel?, GeneralErrorResponse>> GetChannelInfoAsync(string channelId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var result = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<Channel>(result);
    }
    
    public async Task<ApiResponse<Channel?, GeneralErrorResponse>> GetChannelInfoAsync(Channel channel) => await GetChannelInfoAsync(channel.Id);

    public async Task<ApiResponse<Channel?, GeneralErrorResponse>> CreateChannelAsync(string guildId, CreateChannelRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("channels");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        string requestJson = JsonConvert.SerializeObject(request);
        var result = await httpClient.PostAsync(urlBuilder.Build(), new StringContent(requestJson, null, "application/json"));
        return await ResponseTools.GetReturnValueAsync<Channel>(result);
    }
    
    public async Task<ApiResponse<Channel?,GeneralErrorResponse>> CreateChannelAsync(Guild guild, CreateChannelRequest request)
    {
        return await CreateChannelAsync(guild.Id, request);
    }

    public async Task<ApiResponse<Channel?, GeneralErrorResponse>> ModifyChannelPropertyAsync(string channelId, ModifyChannelPropertyRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var result = await httpClient.PatchAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync<Channel>(result);
    }

    public async Task<ApiResponse<Channel?, GeneralErrorResponse>> ModifyChannelPropertyAsync(Channel channel, ModifyChannelPropertyRequest request)
    {
        return await ModifyChannelPropertyAsync(channel.Id, request);
    }

    public async Task<GeneralErrorResponse?> DeleteChannelAsync(string channelId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.DeleteAsync(urlBuilder.Build());
        var ret = await ResponseTools.GetReturnValueAsync(rslt);
        return ret;
    }

    public async Task<GeneralErrorResponse?> DeleteChannelAsync(Channel channel) => await DeleteChannelAsync(channel.Id);

    public async Task<ApiResponse<Member[], GeneralErrorResponse>> GetMembersAsync(string guildId, string? after = null, int? limit = null)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("members");
        urlBuilder.AddArgumentWhenNotNull("after", after).AddArgumentWhenNotNull("limit", limit);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        var ret = await ResponseTools.GetReturnValueAsync<Member[]>(rslt);
        Member[] retArray = Array.Empty<Member>();
        if (ret.Succsee)
        {
            retArray = ret.ResponseObject?.DistinctBy(m => m.User.Id).ToArray() ?? Array.Empty<Member>();
        }

        return new ApiResponse<Member[], GeneralErrorResponse>(retArray, ret.ErrorObject);
    }

    public async Task<ApiResponse<Member[], GeneralErrorResponse>> GetMembersAsync(Guild guild, string? after = null, int? limit = null)
    {
        return await GetMembersAsync(guild.Id, after, limit);
    }

    public async Task<ApiResponse<RoleMembersResponse?, GeneralErrorResponse>> GetRoleMembersAsync(string guildId, int roleId, int? startIndex = null, int? limit = null)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("roles").AddSubLevel(roleId.ToString()).AddSubLevel("members");
        urlBuilder.AddArgumentWhenNotNull("start_index", startIndex).AddArgumentWhenNotNull("limit", limit);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<RoleMembersResponse?>(rslt);
    }

    public async Task<ApiResponse<RoleMembersResponse?, GeneralErrorResponse>> GetRoleMembersAsync(Guild guild, int roleId, int? startIndex = null, int? limit = null)
    {
        return await GetRoleMembersAsync(guild.Id, roleId, startIndex, limit);
    }
    
    public async Task<ApiResponse<Member?, GeneralErrorResponse>> GetMemberInfoAsync(string guildId, int userId, int? startIndex = null, int? limit = null)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("members").AddSubLevel(userId.ToString());
        urlBuilder.AddArgumentWhenNotNull("start_index", startIndex).AddArgumentWhenNotNull("limit", limit);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<Member?>(rslt);
    }

    public async Task<ApiResponse<Member?, GeneralErrorResponse>> GetMemberInfoAsync(Guild guild, int userId, int? startIndex = null, int? limit = null)
    {
        return await GetMemberInfoAsync(guild.Id, userId, startIndex, limit);
    }
    
    public async Task<ApiResponse<Member?, GeneralErrorResponse>> RemoveMemberAsync(string guildId, int userId, bool? addToBlackList = null, int? discardMsgInDays = null)
    {
        if (!ParameterChecker.InValues(discardMsgInDays, -1, 3, 7, 15, 30, null))
        {
            throw new ArgumentOutOfRangeException(nameof(discardMsgInDays), "值只能为-1,3,7,15,30,null");
        }
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("members").AddSubLevel(userId.ToString());
        urlBuilder.AddArgumentWhenNotNull(nameof(addToBlackList), addToBlackList).AddArgumentWhenNotNull(nameof(discardMsgInDays), discardMsgInDays);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<Member?>(rslt);
    }

    public async Task<ApiResponse<Member?, GeneralErrorResponse>> RemoveMemberAsync(Guild guild, int userId, bool? addToBlackList = null, int? discardMsgInDays = null)
    {
        return await RemoveMemberAsync(guild.Id, userId, addToBlackList, discardMsgInDays);
    }

    public async Task<ApiResponse<RolesResponse?, GeneralErrorResponse>> GetRolesAsync(string guildId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("roles");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<RolesResponse?>(rslt);
    }

    public async Task<ApiResponse<RolesResponse?, GeneralErrorResponse>> GetRolesAsync(Guild guild) => await GetRolesAsync(guild.Id);

    public async Task<ApiResponse<CreateRoleResponse?, GeneralErrorResponse>> CreateRoleAsync(string guildId, CreateRoleRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("roles");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var rslt = await httpClient.PostAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync<CreateRoleResponse>(rslt);
    }

    public async Task<ApiResponse<CreateRoleResponse?, GeneralErrorResponse>> CreateRoleAsync(Guild guild, CreateRoleRequest request)
    {
        return await CreateRoleAsync(guild.Id, request);
    }
    
    public async Task<ApiResponse<ModifyChannelPropertyRequest?, GeneralErrorResponse>> ModifyRolePropertyAsync(string guildId, ModifyRoleRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("roles");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var rslt = await httpClient.PostAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync<ModifyChannelPropertyRequest>(rslt);
    }

    public async Task<ApiResponse<ModifyChannelPropertyRequest?, GeneralErrorResponse>> ModifyRolePropertyAsync(Guild guild, ModifyRoleRequest request)
    {
        return await ModifyRolePropertyAsync(guild.Id, request);
    }

    public async Task<GeneralErrorResponse?> AddMemberToRoleAsync(string guildId, string userId, string roleId, string channelId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId);
        urlBuilder.AddSubLevel("members").AddSubLevel(userId);
        urlBuilder.AddSubLevel("roles").AddSubLevel(roleId);
        string data = $"{{\"channel\": {{\"id\":{channelId}}}}}";
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.PutAsync(urlBuilder.Build(), new StringContent(data, null, "application/json"));
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> AddMemberToRoleAsync(Guild guild, User user, Role role, Channel channel)
    {
        return await AddMemberToRoleAsync(guild.Id, user.Id, role.Id, channel.Id);
    }
    
    public async Task<GeneralErrorResponse?> RemoveMemberFromRoleAsync(string guildId, string userId, string roleId, string? channelId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId);
        urlBuilder.AddSubLevel("members").AddSubLevel(userId);
        urlBuilder.AddSubLevel("roles").AddSubLevel(roleId);
        urlBuilder.AddArgumentWhenNotNull("channel", channelId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, urlBuilder.Build());
        JObject jObject = new JObject();
        JObject channelJson = new JObject {{"id", channelId}};
        jObject.Add("channel", channelJson);
        requestMessage.Content = new StringContent(jObject.ToString());
        var rslt = await httpClient.DeleteAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync(rslt);
    }
    public async Task<GeneralErrorResponse?> RemoveMemberFromRoleAsync(Guild guild, User user, Role role, Channel channel)
    {
        return await RemoveMemberFromRoleAsync(guild.Id, user.Id, role.Id, channel.Id);
    }

    public async Task<ApiResponse<ChannelPermissions?, GeneralErrorResponse>> GetUserChannelPermission(string channelId, string roleId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        urlBuilder.AddSubLevel("members").AddSubLevel(roleId).AddSubLevel("permissions");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<ChannelPermissions?>(rslt);
    }

    public async Task<ApiResponse<ChannelPermissions?, GeneralErrorResponse>> GetUserChannelPermission(Channel channel, User user)
    {
        return await GetUserChannelPermission(channel.Id, user.Id);
    }
    
    public async Task<GeneralErrorResponse?> ChangeUserChannelPermission(string channelId, string userId, ChangeChannelPermissionRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        urlBuilder.AddSubLevel("members").AddSubLevel(userId).AddSubLevel("permissions");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var rslt = await httpClient.PutAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> ChangeUserChannelPermission(Channel channel, User user, ChangeChannelPermissionRequest request)
    {
        return await ChangeUserChannelPermission(channel.Id, user.Id, request);
    }
    
    public async Task<ApiResponse<ChannelPermissions?, GeneralErrorResponse>> GetRoleChannelPermission(string channelId, string roleId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        urlBuilder.AddSubLevel("roles").AddSubLevel(roleId).AddSubLevel("permissions");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
         return await ResponseTools.GetReturnValueAsync<ChannelPermissions?>(rslt);
    }

    public async Task<ApiResponse<ChannelPermissions?, GeneralErrorResponse>> GetRoleChannelPermission(Channel channel, Role role)
    {
        return await GetRoleChannelPermission(channel.Id, role.Id);
    }
    
    public async Task<GeneralErrorResponse?> ChangeRoleChannelPermission(string channelId, string roleId, ChangeChannelPermissionRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        urlBuilder.AddSubLevel("roles").AddSubLevel(roleId).AddSubLevel("permissions");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var rslt = await httpClient.PutAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> ChangeRoleChannelPermission(Channel channel, Role role, ChangeChannelPermissionRequest request)
    {
        return await ChangeRoleChannelPermission(channel.Id, role.Id, request);
    }

    public async Task<ApiResponse<Message?, GeneralErrorResponse>> GetMessageAsync(string channelId, string messageId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        urlBuilder.AddSubLevel("messages").AddSubLevel(messageId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<Message?>(rslt);
    }

    public async Task<ApiResponse<Message?, GeneralErrorResponse>> GetMessageAsync(Channel channel, string messageId)
    {
        return await GetMessageAsync(channel.Id, messageId);
    }

    public async Task<ApiResponse<Message?, GeneralErrorResponse>> SendMessageAsync(string channelId, SendMessageRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("messages");
        var jsonString = JsonConvert.SerializeObject(request);
        var jsonContent = new StringContent(jsonString, null, "application/json");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var reqUrl = urlBuilder.Build();
        var rslt = await httpClient.PostAsync(reqUrl, jsonContent);
        return await ResponseTools.GetReturnValueAsync<Message?>(rslt);
    }

    public async Task<ApiResponse<Message?, GeneralErrorResponse>> SendMessageAsync(Channel channel, SendMessageRequest request)
    {
        return await SendMessageAsync(channel.Id, request);
    }

    public async Task<GeneralErrorResponse?> DiscardMessageAsync(string channelId, string messageId, bool? hideTip = null)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        urlBuilder.AddSubLevel("messages").AddSubLevel(messageId);
        urlBuilder.AddArgumentWhenNotNull("hidetip", hideTip);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.DeleteAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> DiscardMessageAsync(Channel channel, Message message, bool? hideTip = null)
    {
        return await DiscardMessageAsync(channel.Id, message.Id, hideTip);
    }

    public async Task<ApiResponse<Message?, GeneralErrorResponse>> SendArkMessageAsync(string channelId, MessageArk messageArk)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("messages");
        var jsonContent = new StringContent(JsonConvert.SerializeObject(messageArk), null, "application/json");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.PostAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync<Message?>(rslt);
    }

    public async Task<ApiResponse<Message?, GeneralErrorResponse>> SendArkMessageAsync(Channel channel, MessageArk messageArk)
    {
        return await SendArkMessageAsync(channel.Id, messageArk);
    }
    
    public async Task<ApiResponse<Message?, GeneralErrorResponse>> SendMarkdownMessageAsync(string channelId, MessageMarkdown messageMarkdown)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("messages");
        var jsonContent = new StringContent(JsonConvert.SerializeObject(messageMarkdown), null, "application/json");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.PostAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync<Message?>(rslt);
    }

    public async Task<ApiResponse<Message?, GeneralErrorResponse>> SendMarkdownMessageAsync(Channel channel, MessageMarkdown messageMarkdown)
    {
        return await SendMarkdownMessageAsync(channel.Id, messageMarkdown);
    }
    
    
    public async Task<ApiResponse<Message?, GeneralErrorResponse>> SendReferenceMessageAsync(string channelId, SendMessageRequest request)
    {
        if (request.Reference == null)
        {
            throw new InvalidOperationException("消息发送请求中的Reference成员在引用消息时不能为null");
        }
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("messages");
        var jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.PostAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync<Message?>(rslt);
    }

    public async Task<ApiResponse<Message?, GeneralErrorResponse>> SendReferenceMessageAsync(Channel channel, SendMessageRequest request)
    {
        return await SendReferenceMessageAsync(channel.Id, request);
    }

    public async Task<ApiResponse<MessageSetting?, GeneralErrorResponse>> GetMessageSendSetting(string guildId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("message").AddSubLevel("setting");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<MessageSetting>(rslt);
    }

    public async Task<ApiResponse<MessageSetting?, GeneralErrorResponse>> GetMessageSendSetting(Guild guild)
    {
        return await GetMessageSendSetting(guild.Id);
    }
    
    public async Task<ApiResponse<DirectMessageSubject?, GeneralErrorResponse>> CreateDirectMessageSubjectSessionAsync
        (CreateDirectMessageRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("@me").AddSubLevel("dms");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var rslt = await httpClient.PostAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync<DirectMessageSubject?>(rslt);

    }

    public async Task<ApiResponse<Message?, GeneralErrorResponse>> SendDirectMessageAsync (string guildId, SendMessageRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("dms").AddSubLevel(guildId).AddSubLevel("messages");
        var jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.PostAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync<Message?>(rslt);
    }

    public async Task<ApiResponse<Message?, GeneralErrorResponse>> SendDirectMessageAsync(Guild guild, SendMessageRequest request)
    {
        return await SendDirectMessageAsync(guild.Id, request);
    }
    
    public async Task<GeneralErrorResponse?> DiscardDirectMessageAsync(string guildId, string messageId, bool? hideTip = null)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("dms").AddSubLevel(guildId);
        urlBuilder.AddSubLevel("messages").AddSubLevel(messageId);
        urlBuilder.AddArgumentWhenNotNull("hidetip", hideTip);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.DeleteAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> DiscardDirectMessageAsync(Guild guild, Message message, bool? hideTip = null)
    {
        return await DiscardDirectMessageAsync(guild.Id, message.Id, hideTip);
    }

    public async Task<GeneralErrorResponse?> MuteAsync(string guildId, MuteRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("mute");
        StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.PatchAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> MuteAsync(Guild guild, MuteRequest request) => await MuteAsync(guild.Id, request);
    
    public async Task<GeneralErrorResponse?> MuteMemberAsync(string guildId, string userId, MuteRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId);
        urlBuilder.AddSubLevel("members").AddSubLevel(userId).AddSubLevel("mute");
        StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.PatchAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync(rslt);
    }
    
    public async Task<GeneralErrorResponse?> MuteMemberAsync(Guild guild, User user, MuteRequest request) => await MuteMemberAsync(guild.Id, user.Id, request);
    
    
    public async Task<GeneralErrorResponse?> MuteSpecifiedMemberAsync(string guildId, string userId, MuteSpecifiedMembersRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId);
        urlBuilder.AddSubLevel("members").AddSubLevel(userId).AddSubLevel("mute");
        StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.PatchAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync(rslt);
    }
    
    public async Task<GeneralErrorResponse?> MuteSpecifiedMemberAsync(Guild guild, User user, MuteSpecifiedMembersRequest request)
    {
        return await MuteSpecifiedMemberAsync(guild.Id, user.Id, request);
    }

    public async Task<ApiResponse<Announcement?, GeneralErrorResponse>> CreateAnnouncementAsync(string guildId, CreateAnnouncementRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("announces");

        StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(request), null, "application/json");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.PostAsync(urlBuilder.Build(), jsonContent);
        var responseJson = JsonConvert.DeserializeObject<JObject>(await rslt.Content.ReadAsStringAsync()) ?? new JObject();
        return await ResponseTools.GetReturnValueAsync<Announcement?>(rslt);
    }
    
    public async Task<ApiResponse<Announcement?, GeneralErrorResponse>> CreateAnnouncementAsync(Guild guild, CreateAnnouncementRequest request)
    {
        return await CreateAnnouncementAsync(guild.Id, request);
    }
    
    public async Task<GeneralErrorResponse?> RemoveAnnouncementAsync(string guildId, string messageId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("announces").AddSubLevel(messageId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.DeleteAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync(rslt);
    }
    
    public async Task<GeneralErrorResponse?> RemoveAnnouncementAsync(Guild guild, Message message)
    {
        return await RemoveAnnouncementAsync(guild.Id, message.Id);
    }

    public async Task<ApiResponse<PinsMessage?, GeneralErrorResponse>> AddPinsMessageAsync(string channelId, string messageId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("pins").AddSubLevel(messageId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.PutAsync(urlBuilder.Build(), null);
        return await ResponseTools.GetReturnValueAsync<PinsMessage>(rslt);
    }

    public async Task<ApiResponse<PinsMessage?, GeneralErrorResponse>> AddPinsMessageAsync(Channel channel, Message message)
    {
        return await AddPinsMessageAsync(channel.Id, message.Id);
    }

    public async Task<GeneralErrorResponse?> DeletePinsMessageAsync(string channelId, string messageId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("pins").AddSubLevel(messageId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.DeleteAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> DeletePinsMessageAsync(Channel channel, Message message)
    {
        return await DeletePinsMessageAsync(channel.Id, message.Id);
    }
    
    public async Task<ApiResponse<PinsMessage?, GeneralErrorResponse>> GetPinsMessageAsync(string channelId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("pins");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<PinsMessage?>(rslt);
    }

    public async Task<ApiResponse<PinsMessage?, GeneralErrorResponse>> GetPinsMessageAsync(Channel channel)
    {
        return await GetPinsMessageAsync(channel.Id);
    }

    public async Task<ApiResponse<Schedule[]?, GeneralErrorResponse>> GetSchedulesAsync(string channelId)
    {
        //GET /channels/{channel_id}/schedules
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("schedules");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<Schedule[]>(rslt);
    }

    public async Task<ApiResponse<Schedule[]?, GeneralErrorResponse>> GetSchedulesAsync(Channel channel) => await GetSchedulesAsync(channel.Id);
    
    public async Task<ApiResponse<Schedule[]?, GeneralErrorResponse>> GetScheduleInfoAsync(string channelId, string scheduleId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        urlBuilder.AddSubLevel("schedules").AddSubLevel(scheduleId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<Schedule[]>(rslt);
    }

    public async Task<ApiResponse<Schedule[]?, GeneralErrorResponse>> GetScheduleInfoAsync(Channel channel, Schedule schedule)
    {
        return await GetScheduleInfoAsync(channel.Id, schedule.Id);
    }

    public async Task<ApiResponse<Schedule?, GeneralErrorResponse>> CreateScheduleAsync(string channelId, Schedule schedule)
    {
        //POST /channels/{channel_id}/schedules
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("schedules");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(schedule), null, "application/json");
        var rslt = await httpClient.PostAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync<Schedule>(rslt);
    }

    public async Task<ApiResponse<Schedule?, GeneralErrorResponse>> CreateScheduleAsync(Channel channel, Schedule schedule)
    {
        return await CreateScheduleAsync(channel.Id, schedule);
    }
    
    public async Task<ApiResponse<Schedule?, GeneralErrorResponse>> ModifyScheduleAsync(string channelId, Schedule schedule)
    {
        //POST /channels/{channel_id}/schedules
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("schedules");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(schedule), null, "application/json");
        var rslt = await httpClient.PostAsync(urlBuilder.Build(), jsonContent);
        return await ResponseTools.GetReturnValueAsync<Schedule>(rslt);
    }

    public async Task<ApiResponse<Schedule?, GeneralErrorResponse>> ModifyScheduleAsync(Channel channel, Schedule schedule)
    {
        return await ModifyScheduleAsync(channel.Id, schedule);
    }
    
    public async Task<GeneralErrorResponse?> DeleteScheduleAsync(string channelId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("schedules");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
       
        var rslt = await httpClient.DeleteAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> DeleteScheduleAsync(Channel channel)
    {
        return await DeleteScheduleAsync(channel.Id);
    }

    public async Task<GeneralErrorResponse?> PublishMessageReactionAsync(string channelId, string messageId, EmojiType type, string emojiId)
    {
        //PUT /channels/{channel_id}/messages/{message_id}/reactions/{type}/{id}
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        urlBuilder.AddSubLevel("messages").AddSubLevel(messageId);
        urlBuilder.AddSubLevel("reactions").AddSubLevel(((int)type).ToString()).AddSubLevel(emojiId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
       
        var rslt = await httpClient.PutAsync(urlBuilder.Build(), null);
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> PublishMessageReactionAsync(Channel channel, Message message, EmojiType type, string emojiId)
    {
        return await PublishMessageReactionAsync(channel.Id, message.Id, type, emojiId);
    }

    public async Task<ApiResponse<Schedule[]?, GeneralErrorResponse>> DeleteMessageReactionAsync(string channelId, string messageId, EmojiType type, string emojiId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        urlBuilder.AddSubLevel("messages").AddSubLevel(messageId);
        urlBuilder.AddSubLevel("reactions").AddSubLevel(((int)type).ToString()).AddSubLevel(emojiId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
       
        var rslt = await httpClient.DeleteAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<Schedule[]>(rslt);
    }

    public async Task<ApiResponse<Schedule[]?, GeneralErrorResponse>> DeleteMessageReactionAsync(Channel channel, Message message, EmojiType type, string emojiId)
    {
        return await DeleteMessageReactionAsync(channel.Id, message.Id, type, emojiId);
    }
    
    public async Task<ApiResponse<GetMessageReactionUserResponse?, GeneralErrorResponse>> 
        GetMessageReactionsAsync(string channelId, string messageId, EmojiType type, string emojiId, string? cookie, int? limit)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId);
        urlBuilder.AddSubLevel("messages").AddSubLevel(messageId);
        urlBuilder.AddSubLevel("reactions").AddSubLevel(((int)type).ToString()).AddSubLevel(emojiId);
        urlBuilder.AddArgumentWhenNotNull("cookie", cookie);
        urlBuilder.AddArgumentWhenNotNull("limit", limit);
        
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<GetMessageReactionUserResponse>(rslt);
    }

    public async Task<ApiResponse<GetMessageReactionUserResponse?, GeneralErrorResponse>> GetMessageReactionsAsync
        (Channel channel, Message message, EmojiType type, string emojiId, string? cookie, int? limit)
    {
        return await GetMessageReactionsAsync(channel.Id, message.Id, type, emojiId, cookie, limit);
    }

    public async Task<GeneralErrorResponse?> ControlAudioAsync(string channelId, AudioControl audioControl)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("audio");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(audioControl), null, "application/json");
        var rslt = await httpClient.PostAsync(urlBuilder.Build(), jsonContent);
        string responseText = await rslt.Content.ReadAsStringAsync();
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> ControlAudioAsync(Channel channel, AudioControl audioControl) => await ControlAudioAsync(channel.Id, audioControl);
    
    public async Task<GeneralErrorResponse?> TurnOnMicAsync(string channelId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("mic");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.PutAsync(urlBuilder.Build(), null);
        string responseText = await rslt.Content.ReadAsStringAsync();
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> TurnOnMicAsync(Channel channel) => await TurnOnMicAsync(channel.Id);
    
    public async Task<GeneralErrorResponse?> TurnOffMicAsync(string channelId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("mic");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.DeleteAsync(urlBuilder.Build());
        string responseText = await rslt.Content.ReadAsStringAsync();
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> TurnOffMicAsync(Channel channel) => await TurnOffMicAsync(channel.Id);

    public async Task<ApiResponse<GetThreadsResponse?, GeneralErrorResponse>> GetThreadsAsync(string channelId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("threads");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<GetThreadsResponse>(rslt);
    }

    public async Task<ApiResponse<GetThreadsResponse?, GeneralErrorResponse>> GetThreadsAsync(Channel channel) =>
        await GetThreadsAsync(channel.Id);

    public async Task<ApiResponse<ForumThreadInfo?, GeneralErrorResponse>> GetThreadInfoAsync(string channelId, string threadId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("threads").AddSubLevel(threadId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<ForumThreadInfo>(rslt);
    }

    public async Task<ApiResponse<ForumThreadInfo?, GeneralErrorResponse>> GetThreadInfoAsync(Channel channel, ForumThread forumThread) =>
        await GetThreadInfoAsync(channel.Id, forumThread.ForumThreadInfo.ThreadId);


    public async Task<ApiResponse<CreateThreadResponse?, GeneralErrorResponse>> CreateForumThreadAsync(string channelId, CreateForumThreadRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("threads");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        string content = JsonConvert.SerializeObject(request);
        StringContent sendContent = new StringContent(content, null, "application/json");
        var rslt = await httpClient.PutAsync(urlBuilder.Build(), sendContent);
        return await ResponseTools.GetReturnValueAsync<CreateThreadResponse>(rslt);
    }

    public async Task<ApiResponse<CreateThreadResponse?, GeneralErrorResponse>> CreateForumThreadAsync(Channel channel, CreateForumThreadRequest request) =>
        await CreateForumThreadAsync(channel.Id, request);

    public async Task<GeneralErrorResponse?> DeleteThreadInfoAsync(string channelId, string threadId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("channels").AddSubLevel(channelId).AddSubLevel("threads").AddSubLevel(threadId);
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.DeleteAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync(rslt);
    }

    public async Task<GeneralErrorResponse?> DeleteThreadInfoAsync(Channel channel, ForumThread forumThread) =>
        await DeleteThreadInfoAsync(channel.Id, forumThread.ForumThreadInfo.ThreadId);

    public async Task<ApiResponse<GetApiPermissionsResponse?, GeneralErrorResponse>> GetGuildApiPermissions(
        string guildId)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("api_permission");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var rslt = await httpClient.GetAsync(urlBuilder.Build());
        return await ResponseTools.GetReturnValueAsync<GetApiPermissionsResponse>(rslt);
    }

    public async Task<ApiResponse<GetApiPermissionsResponse?, GeneralErrorResponse>> GetGuildApiPermissions(Guild guild) => 
        await GetGuildApiPermissions(guild.Id);

    public async Task<ApiResponse<ApiPermissionDemand?, GeneralErrorResponse>> CreateApiPermissionRequestLink
        (string guildId, CreateApiAuthenticateRequestLinkRequest request)
    {
        UrlBuilder urlBuilder = new UrlBuilder(GetBaseUrl());
        urlBuilder.AddSubLevel("guilds").AddSubLevel(guildId).AddSubLevel("api_permission").AddSubLevel("demand");
        var httpClient = BotIdentifier.GetBotTokenAuthenticateHttpClient();
        string content = JsonConvert.SerializeObject(request);
        StringContent sendContent = new StringContent(content, null, "application/json");
        var rslt = await httpClient.PutAsync(urlBuilder.Build(), sendContent);
        return await ResponseTools.GetReturnValueAsync<ApiPermissionDemand>(rslt);
    }

    public async Task<ApiResponse<ApiPermissionDemand?, GeneralErrorResponse>> CreateApiPermissionRequestLink(
        Guild guild, CreateApiAuthenticateRequestLinkRequest request)
        => await CreateApiPermissionRequestLink(guild.Id, request);
}