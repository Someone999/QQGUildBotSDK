using Newtonsoft.Json;
using QqGuildRobotSdk.Models.Forums;

namespace QqGuildRobotSdk.Response
{
    public class GetThreadsResponse
    {
        [JsonProperty("threads")]
        public ForumThread[] Threads { get; private set; } = Array.Empty<ForumThread>();

        [JsonProperty("is_finished")]
        public bool IsFinished { get; private set; }
    }
}
