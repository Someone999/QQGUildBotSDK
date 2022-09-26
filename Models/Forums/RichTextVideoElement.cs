using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class RichTextVideoElement
{
    [JsonProperty("third_url")]
    public string Url { get; private set; } = "";

}