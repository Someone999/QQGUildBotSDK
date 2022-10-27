using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class RichTextPlatVideo
{
    [JsonProperty("url")]
    public string Url { get; private set; } = "";

    [JsonProperty("width")]
    public double Width { get; private set; }

    [JsonProperty("height")]
    public double Height { get; private set; }

    [JsonProperty("video_id")]
    public string VideoId { get; private set; } = "";

    [JsonProperty("duration")]
    public uint Duration { get; private set; }

    [JsonProperty("cover")]
    public RichTextPlatImage Cover { get; private set; } = new RichTextPlatImage();
}