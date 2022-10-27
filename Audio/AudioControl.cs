using Newtonsoft.Json;

namespace QqGuildRobotSdk.Audio;

public class AudioControl
{
    [JsonProperty("audio_url")]
    public string AudioUrl { get; set; } = "";
    
    [JsonProperty("text")]
    public string StatusText { get; set; } = "";
    
    [JsonProperty("status")]
    public AudioStatus AudioStatus { get; set; }
}