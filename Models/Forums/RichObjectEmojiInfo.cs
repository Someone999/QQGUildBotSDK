using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class RichObjectEmojiInfo
{
    [JsonProperty("id")]
    public string Id { get; private set; } = "";

    [JsonProperty("type")]
    public string EmojiType { get; private set; } = "";

    [JsonProperty("name")]
    public string Name { get; private set; } = "";

    [JsonProperty("url")]
    public string Url { get; private set; } = "";
}