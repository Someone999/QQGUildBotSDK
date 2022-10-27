using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class ParagraphProps
{
    [JsonProperty("alignment")]
    public ParagraphAlignment Alignment { get; private set; }
}