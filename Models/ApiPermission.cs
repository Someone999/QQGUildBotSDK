using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models
{
    public class ApiPermission
    {
        [JsonProperty("path")]
        public string Path { get; private set; } = "";

        [JsonProperty("method")]
        public string Method { get; private set; } = "";

        [JsonProperty("desc")]
        public string Description { get; private set; } = "";

        [JsonProperty("auth_status")]
        public bool AuthenticateStatus { get; private set; } 
    }

    public class ApiPermissionDemand
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; private set; } = "";

        [JsonProperty("channel_id")]
        public string ChannelId { get; private set; } = "";

        [JsonProperty("api_identify")]
        public ApiPermissionDemandIdentify Identify { get; private set; } = new ApiPermissionDemandIdentify();

        [JsonProperty("title")]
        public string Title { get; private set; } = "";

        [JsonProperty("desc")]
        public string Description { get; private set; } = "";
    }

    public class ApiPermissionDemandIdentify
    {
        [JsonProperty("path")]
        public string Path { get; private set; } = "";

        [JsonProperty("method")]
        public string Method { get; private set; } = "";
    }
}
