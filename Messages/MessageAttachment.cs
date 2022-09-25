using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages;

public class MessageAttachment
{
    [JsonProperty("url")]
    public string Url { get; set; } = "";
}