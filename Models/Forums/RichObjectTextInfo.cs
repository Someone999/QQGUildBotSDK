using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class RichObjectTextInfo
{
    [JsonProperty("text")]
    public string Text { get; private set; } = "";

}