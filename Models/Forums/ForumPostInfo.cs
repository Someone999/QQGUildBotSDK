using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class ForumPostInfo
{
    [JsonProperty("thread_id")]
    public string ThreadId { get; private set; } = "";

    [JsonProperty("post_id")]
    public string PostId { get; private set; } = "";

    [JsonProperty("content")]

    public string Content { get; private set; } = "";

    [JsonProperty("date_time")]

    public string DateTime { get; private set; } = "";

    public static ForumPostInfo Empty { get; } = new ForumPostInfo();
}