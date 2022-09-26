using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class ParagraphProps
{
    [JsonProperty("alignment")]
    public ParagraphAlignment Alignment { get; private set; }
}