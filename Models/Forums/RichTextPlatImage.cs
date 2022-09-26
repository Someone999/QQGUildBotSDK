using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class RichTextPlatImage
{
    [JsonProperty("url")]
    public string Url { get; private set; } = "";

    [JsonProperty("width")]
    public double Width { get; private set; }

    [JsonProperty("height")]
    public double Height { get; private set; }

    [JsonProperty("image_id")]
    public string ImageId { get; private set; } = "";
}