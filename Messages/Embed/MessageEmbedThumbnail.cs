using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Embed;

public class MessageEmbedThumbnail
{
    [JsonProperty("url")]
    public string Url { get; set; } = "";
}