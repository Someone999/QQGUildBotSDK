using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models;

public class ApiPermissionDemand
{
    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = "";

    [JsonProperty("channel_id")]
    public string ChannelId { get; set; } = "";

    [JsonProperty("api_identify")]
    public ApiPermissionDemandIdentify Identify { get; set; } = new ApiPermissionDemandIdentify();

    [JsonProperty("title")]
    public string Title { get; set; } = "";

    [JsonProperty("desc")]
    public string Description { get; set; } = "";
}