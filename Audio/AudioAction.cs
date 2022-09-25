using Newtonsoft.Json;

namespace QqChannelRobotSdk.Audio;

public class AudioAction
{
    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = "";

    [JsonProperty("channel_id")]
    public string ChannelId { get; set; } = "";

    [JsonProperty("audio_url")]
    public string AudioUrl { get; set; } = "";
    
    [JsonProperty("text")]
    public string Status { get; set; } = "";
}