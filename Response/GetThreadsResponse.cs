using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using QqChannelRobotSdk.Models.Forums;

namespace QqChannelRobotSdk.Response
{
    public class GetThreadsResponse
    {
        [JsonProperty("threads")]
        public ForumThread[] Threads { get; private set; } = Array.Empty<ForumThread>();

        [JsonProperty("is_finished")]
        public bool IsFinished { get; private set; }
    }
}
