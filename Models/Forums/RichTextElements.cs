using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class RichTextElements
{
    [JsonProperty("text")]
    public RichTextTextElement? TextElement { get; private set; }

    [JsonProperty("image")]
    public RichTextImageElement? ImageElement { get; private set; }

    [JsonProperty("video")]
    public RichTextVideoElement? VideoElement { get; private set; }

    [JsonProperty("url")]
    public RichTextUrlElement? UrlElement { get; private set; }

    [JsonProperty("type")]
    public RichTextElementType ElementType { get; private set; }

    public static RichTextElements Empty { get; } = new RichTextElements();
}