using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class RichText
{
    [JsonProperty("paragraphs")]
    public Paragraph Paragraphs { get; private set; } = new Paragraph();
}