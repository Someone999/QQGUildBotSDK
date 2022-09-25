using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages;

public class PinsMessage
{
    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = "";
    
    [JsonProperty("channel_id")]
    public string ChannelId { get; set; } = "";

    [JsonProperty("message_ids")]
    public List<string> MessageIds { get; set; } = new List<string>();
}