using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Embed;

public class MessageEmbedThumbnail
{
    [JsonProperty("url")]
    public string Url { get; set; } = "";
}