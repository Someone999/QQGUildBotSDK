using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QqChannelRobotSdk.Models;

namespace QqChannelRobotSdk.Request
{
    public class CreateApiAuthenticateRequestLinkRequest
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; } = "";

        [JsonProperty("api_identify")]
        public ApiPermissionDemandIdentify Identify { get; set; } = new ApiPermissionDemandIdentify();

        [JsonProperty("desc")]
        public string Description { get; set; } = "";
    }
}
