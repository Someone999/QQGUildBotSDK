using Newtonsoft.Json;

namespace QqGuildRobotSdk.WebSocket.Models;

public class MultiShardWebSocketConnectionInfo
{
    [JsonProperty("url")]
    public string Url { get; private set; } = "";
    
    [JsonProperty("shards")]
    public int RecommendedShards { get; private set; }
    
    [JsonProperty("session_start_limit")]
    public SessionStartLimit SessionStartLimit { get; private set; }
}

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