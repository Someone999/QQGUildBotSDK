using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class RichObjectTextInfo
{
    [JsonProperty("text")]
    public string Text { get; private set; } = "";

}