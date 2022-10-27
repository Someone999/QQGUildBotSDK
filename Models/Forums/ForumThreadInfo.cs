using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class ForumThreadInfo
{
    [JsonProperty("thread_id")]
    public string ThreadId { get; private set; } = "";

    [JsonProperty("title")]
    public string Title { get; private set; } = "";

    [JsonProperty("content")]

    public RichText Content { get; private set;} = new RichText();

    [JsonProperty("date_time")]

    public string DateTime { get; private set; } = "";

    public static ForumThreadInfo Empty { get; } = new ForumThreadInfo();
}