using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class RichTextTextElement
{
    [JsonProperty("text")]
    public string Text { get; private set; } = "";

    [JsonProperty("props")]
    public RichTextTextProps TextProps { get; private set; } = RichTextTextProps.Default;
}