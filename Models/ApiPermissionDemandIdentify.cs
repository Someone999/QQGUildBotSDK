using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models;

public class ApiPermissionDemandIdentify
{
    [JsonProperty("path")]
    public string Path { get; set; } = "";

    [JsonProperty("method")]
    public string Method { get; set; } = "";
}