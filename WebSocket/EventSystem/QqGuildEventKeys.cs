using QqGuildRobotSdk.Attributes;

namespace QqGuildRobotSdk.WebSocket.EventSystem;

public static class QqGuildEventKeys
{
    public const string UnhandledPacket = "SystemEvent.UnhandledPacket->GenericEvent<ServerPacketBase>";
    public const string UndefinedPacket = "SystemEvent.UndefinedPacket->GenericEvent<ServerPacketBase>";
    public const string WebSocketReadied = "SystemEvent.WebSocketReadied->GenericEvent<PacketReceivedEventArgs>";
    public const string WebSocketFailed = "SystemEvent.WebSocketFailed->GenericEvent<PacketReceivedEventArgs>";
    public const string AudioFinishEvent = "QqGuildEvent.Audio.Finish->QqGuildSdkEvent<AudioEventArgs>";
    public const string AudioStartEvent = "QqGuildEvent.Audio.Start->QqGuildSdkEvent<AudioEventArgs>";
    public const string AudioTurnOffMicEvent = "QqGuildEvent.Audio.TrunOffMic->QqGuildSdkEvent<AudioEventArgs>";
    public const string AudioTurnOnMic = "QqGuildEvent.Audio.TurnOnMic->QqGuildSdkEvent<AudioEventArgs>";
    public const string ForumPostCreate = "QqGuildEvent.Forum.Post.Create->QqGuildSdkEvent<ForumPostEventArgs>";
    public const string ForumPostDelete = "QqGuildEvent.Forum.Post.Delete->QqGuildSdkEvent<ForumPostEventArgs>";
    public const string ForumReplyCreate = "QqGuildEvent.Forum.Reply.Create->QqGuildSdkEvent<ForumReplyEventArgs>";
    public const string ForumReplyDelete = "QqGuildEvent.Forum.Reply.Delete->QqGuildSdkEvent<ForumReplyEventArgs>";

    public const string ForumPublishAuditResult =
        "QqGuildEvent.Forum.PublishAuditResult->QqGuildSdkEvent<DirectCreateMessageEventArgs>";
    public const string ForumThreadCreate = "QqGuildEvent.Forum.Thread.Create->QqGuildSdkEvent<ForumThreadEventArgs>";
    public const string ForumThreadDelete = "QqGuildEvent.Forum.Thread.Delete->QqGuildSdkEvent<ForumThreadEventArgs>";
    public const string ForumThreadUpdate = "QqGuildEvent.Forum.Thread.Update->QqGuildSdkEvent<ForumThreadEventArgs>";
    public const string GuildChannelCreate = "QqGuildEvent.Guild.Channel.Create->QqGuildSdkEvent<ChannelEventArgs>";
    public const string GuildChannelDelete = "QqGuildEvent.Guild.Channel.Delete->QqGuildSdkEvent<ChannelEventArgs>";
    public const string GuildChannelUpdate = "QqGuildEvent.Guild.Channel.Update->QqGuildSdkEvent<ChannelEventArgs>";

    public const string GuildDirectMessageCreate =
        "QqGuildEvent.DirectMessage.Create->QqGuildSdkEvent<DirectCreateMessageEventArgs>";

    public const string GuildDirectMessageRemove =
        "QqGuildEvent.DirectMessage.Remove->QqGuildSdkEvent<DirectDeleteMessageEventArgs>";
    public const string GuildMemberJoined = "QqGuildEvent.Member.Joined->QqGuildSdkEvent<GuildMemberEventArgs>";
    public const string GuildMemberRemoved = "QqGuildEvent.Member.Removed->QqGuildSdkEvent<GuildMemberEventArgs>";
    public const string GuildMemberInfoUpdated = "QqGuildEvent.Member.InfoUpdated->QqGuildSdkEvent<GuildMemberEventArgs>";
    public const string GuildMessageReactionAdd = "QqGuildEvent.Guild.MessageReaction.Add->QqGuildSdkEvent<MessageReactionEventArgs>";
    public const string GuildMessageReactionRemove = "QqGuildEvent.Guild.MessageReaction.Remove->QqGuildSdkEvent<MessageReactionEventArgs>";
    public const string GuildCreate = "QqGuildEvent.Guild.Create->QqGuildSdkEvent<GuildEventArgs>";
    public const string GuildDelete = "QqGuildEvent.Guild.Delete->QqGuildSdkEvent<GuildEventArgs>";
    public const string GuildUpdate = "QqGuildEvent.Guild.Update->QqGuildSdkEvent<GuildEventArgs>";
    public const string MessageAuditPassed = "QqGuildEvent.Guild.MessageAuditPassed->QqGuildSdkEvent<MessageAuditEventArgs>";
    public const string MessageAuditRejected = "QqGuildEvent.Guild.MessageAuditRejected->QqGuildSdkEvent<MessageAuditEventArgs>";
    
    [WorkInProgress("I currently do not have a structural definition for event data.")]
    public const string InteractionMessageCreate = "QqGuildEvent.Message.Interaction.Create";
    public const string AtMessageCreate = "QqGuildEvent.Message.At.Create->QqGuildSdkEvent<MessageCreateEventArgs>";
    public const string MessageCreate = "QqGuildEvent.Message.Create->QqGuildSdkEvent<MessageCreateEventArgs>";
    public const string MessageDelete = "QqGuildEvent.Message.Delete->QqGuildSdkEvent<MessageDeleteEventArgs>";
    public const string PublicMessageDelete = "QqGuildEvent.Message.Public.Delete->QqGuildSdkEvent<MessageDeleteEventArgs>";
    
    [InternalUseOnly("No code will raise this event currently.")]
    public const string HeartbeatAck = "QqGuildEvent.Server.HeartbeatAck";
    
    [InternalUseOnly("No code will raise this event currently.")]
    public const string InvalidSession = "QqGuildEvent.Server.InvalidSession";
    
    [InternalUseOnly("No code will raise this event currently.")]
    public const string Reconnect = "QqGuildEvent.Server.Reconnect";
    
    [InternalUseOnly("No code will raise this event currently.")]
    public const string Resume = "QqGuildEvent.Server.Resume";
}