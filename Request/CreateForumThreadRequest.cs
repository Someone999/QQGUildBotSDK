using Newtonsoft.Json;

namespace QqGuildRobotSdk.Request
{
    public class CreateForumThreadRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; } = "";

        [JsonProperty("content")]
        public string Content { get; set; } = "";

        [JsonProperty("format")]
        public ThreadFormat ThreadFormat { get; set; }

    }
}
