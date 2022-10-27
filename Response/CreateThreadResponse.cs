using Newtonsoft.Json;

namespace QqGuildRobotSdk.Response
{
    public class CreateThreadResponse
    {
        [JsonProperty("task_id")]
        public string TaskId { get; private set; } = "";

        [JsonProperty("create_time")]
        public string CreateTime { get; private set; } = "";
    }
}
