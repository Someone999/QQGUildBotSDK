using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class Paragraph
{
    [JsonProperty("elems")]
    public RichTextElements Elements { get; private set; } = new RichTextElements();

    [JsonProperty("props")]
    public ParagraphProps ParagraphProps { get; private set; } = new ParagraphProps();

    public static Paragraph Empty { get; } = new Paragraph();
}