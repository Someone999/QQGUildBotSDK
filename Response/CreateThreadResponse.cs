using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QqChannelRobotSdk.Response
{
    public class CreateThreadResponse
    {
        [JsonProperty("task_id")]
        public string TaskId { get; private set; } = "";

        [JsonProperty("create_time")]
        public string CreateTime { get; private set; } = "";
    }
}
