using Newtonsoft.Json;

namespace QqChannelRobotSdk.Request;

public class MuteRequest
{
    [JsonProperty("mute_end_timestamp")]
    public string MuteEndTimestamp { get; set; } = "0";
    
    [JsonProperty("mute_seconds")]
    public string MuteSeconds { get; set; } = "0";
}