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