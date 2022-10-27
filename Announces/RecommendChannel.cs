using Newtonsoft.Json;

namespace QqGuildRobotSdk.Announces;

public class RecommendChannel
{
    
    [JsonProperty("channel_id")]
    public string? ChannelId { get; private set; }
    
    [JsonProperty("introduce")]
    public string? Introduce { get; private set; }
}