using Newtonsoft.Json;

namespace QqGuildRobotSdk.Request;

public class CreateDirectMessageRequest
{
    [JsonProperty("recipient_id")]
    public string ReciverId { get; set; } = "";

    [JsonProperty("source_guild_id")]
    public string SourceGuildLine { get; set; } = "";
}