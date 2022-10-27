using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Embed;

public class MessageEmbedField
{
    [JsonProperty("name")]
    public string Name { get; set; } = "";
}