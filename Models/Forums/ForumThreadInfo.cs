using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class ForumThreadInfo
{
    [JsonProperty("thread_id")]
    public string ThreadId { get; private set; } = "";

    [JsonProperty("title")]
    public string Title { get; private set; } = "";

    [JsonProperty("content")]

    public string Content { get; private set;} = "";

    [JsonProperty("date_time")]

    public string DateTime { get; private set; } = "";

    public static ForumThreadInfo Empty { get; } = new ForumThreadInfo();
}