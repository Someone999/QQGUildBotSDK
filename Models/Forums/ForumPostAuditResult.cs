using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class ForumPostAuditResult
{
    [JsonProperty("guild_id")]
    public string GuildId { get; private set; } = "";

    [JsonProperty("channel_id")]
    public string ChannelId { get; private set; } = "";


    [JsonProperty("author_id")]
    public string AuthorId { get; private set; } = "";

    [JsonProperty("thread_id")]
    public string ThreadId { get; private set; } = "";

    [JsonProperty("post_id")]
    public string PostId { get; private set; } = "";

    [JsonProperty("reply_id")]
    public string ReplyId { get; private set; } = "";

    [JsonProperty("type")]
    public bool Result { get; private set; }

    [JsonProperty("err_msg")]
    public string? ErrorMessage { get; private set; }

}