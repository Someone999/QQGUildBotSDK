using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class ForumReplyInfo
{
    [JsonProperty("thread_id")]
    public string ThreadId { get; private set; } = "";

    [JsonProperty("post_id")]
    public string PostId { get; private set; } = "";

    [JsonProperty("reply_id")]
    public string ReplyId { get; private set; } = "";

    [JsonProperty("content")]

    public string Content { get; private set; } = "";

    [JsonProperty("date_time")]

    public string DateTime { get; private set; } = "";

    public static ForumReplyInfo Empty { get; } = new ForumReplyInfo();
}