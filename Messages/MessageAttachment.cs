using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages;

public class MessageAttachment
{
    [JsonProperty("url")]
    public string Url { get; set; } = "";
}