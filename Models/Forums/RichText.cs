using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class RichText
{
    [JsonProperty("paragraphs")]
    public Paragraph Paragraphs { get; private set; } = new Paragraph();
}