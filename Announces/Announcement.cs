using Newtonsoft.Json;

namespace QqGuildRobotSdk.Announces;

public class Announcement
{
    [JsonProperty("guild_id")]
    public string GuildId { get; private set; } = "";

    [JsonProperty("channel_id")]
    public string ChannelId { get; private set; } = "";

    [JsonProperty("message_id")]
    public string MessageId { get; private set; } = "";

    [JsonProperty("announces_type")]
    public AnnouncementType AnnouncementType { get; private set; }
    
    [JsonProperty("recommend_channels")]
    public List<RecommendChannel>? RecommendChannels { get; private set; }
}