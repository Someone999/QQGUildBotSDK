using Newtonsoft.Json;

namespace QqGuildRobotSdk.WebSocket.Models;

public struct SessionStartLimit
{
    [JsonProperty("total")]
    public int Total { get; private set; }
    
    [JsonProperty("remaining")]
    public int Remaining { get; private set; }
    
    [JsonProperty("reset_after")]
    public int ResetAfter { get; private set; }
    
    [JsonProperty("max_concurrency")]
    public int MaxConcurrency { get; private set; }
}