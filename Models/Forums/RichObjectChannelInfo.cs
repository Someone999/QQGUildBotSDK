using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class RichObjectChannelInfo
{
    [JsonProperty("channel_id")]
    public string ChannelId { get; private set; } = "";

       

    [JsonProperty("channel_name")]
    public string ChannelName { get; private set; } = "";
}