using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Embed;

public class MessageEmbedField
{
    [JsonProperty("name")]
    public string Name { get; set; } = "";
}