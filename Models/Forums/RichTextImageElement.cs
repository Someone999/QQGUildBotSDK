using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class RichTextImageElement
{
    [JsonProperty("third_url")]
    public string Url { get; private set; } = "";

    [JsonProperty("width_percent")]
    public double WidthPercent { get; private set; }
}