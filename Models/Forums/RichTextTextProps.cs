using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class RichTextTextProps
{
    [JsonProperty("font_bold")]
    public bool Bold { get; private set; }

    [JsonProperty("italic")]
    public bool Italic { get; private set; }

    [JsonProperty("underline")]
    public bool Underline { get; private set; }

    public static RichTextTextProps Default { get; } = new RichTextTextProps();
}