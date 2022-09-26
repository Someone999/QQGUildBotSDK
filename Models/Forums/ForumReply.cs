using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class ForumReply
{
    [JsonProperty("guild_id")]
    public string GuildId { get; private set; } = "";

    [JsonProperty("channel_id")]
    public string ChannelId { get; private set; } = "";


    [JsonProperty("author_id")]
    public string AuthorId { get; private set; } = "";

    //[JsonProperty("guild_id")]
    [JsonProperty("reply_info")]
    public ForumReplyInfo ForumReplyInfo { get; private set; } = ForumReplyInfo.Empty;


}