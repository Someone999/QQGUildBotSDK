using Newtonsoft.Json;
using QqGuildRobotSdk.Models;

namespace QqGuildRobotSdk.Request
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
