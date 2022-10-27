using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Messages;

public class DirectMessageSubject
{
    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = "";

    [JsonProperty("channel_id")]
    public string ChannelId { get; set; } = "";

    [JsonProperty("create_time")]
    public string CreateTime { get; set; } = "";
}