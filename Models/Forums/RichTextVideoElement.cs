using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class RichTextVideoElement
{
    [JsonProperty("third_url")]
    public string Url { get; private set; } = "";

}