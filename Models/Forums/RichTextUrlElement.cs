using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class RichTextUrlElement
{
    [JsonProperty("third_url")]
    public string Url { get; private set; } = "";

    [JsonProperty("desc")]
    public string Description { get; private set; } = "";
}