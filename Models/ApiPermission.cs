using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models
{
    public class ApiPermission
    {
        [JsonProperty("path")]
        public string Path { get; set; } = "";

        [JsonProperty("method")]
        public string Method { get; set; } = "";

        [JsonProperty("desc")]
        public string Description { get; set; } = "";

        [JsonProperty("auth_status")]
        public bool AuthenticateStatus { get; set; }

        public override string ToString() => $"{Description} 已授权: {(AuthenticateStatus ? "是" : "否")}";

    }
}
