using Newtonsoft.Json;
using QqChannelRobotSdk.Announces;

namespace QqChannelRobotSdk.Request;

public class CreateAnnouncementRequest
{
    [JsonProperty("channel_id")]
    public string ChannelId { get; private set; } = "";

    [JsonProperty("message_id")]
    public string MessageId { get; private set; } = "";

    [JsonProperty("announces_type")]
    public AnnouncementType AnnouncementType { get; private set; }
    
    [JsonProperty("recommend_channels")]
    public List<RecommendChannel>? RecommendChannels { get; private set; }
}