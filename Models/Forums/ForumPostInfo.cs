using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class ForumPostInfo
{
    [JsonProperty("thread_id")]
    public string ThreadId { get; private set; } = "";

    [JsonProperty("post_id")]
    public string PostId { get; private set; } = "";

    [JsonProperty("content")]

    public RichText Content { get; private set; } = new RichText();

    [JsonProperty("date_time")]

    public string DateTime { get; private set; } = "";

    public static ForumPostInfo Empty { get; } = new ForumPostInfo();
}