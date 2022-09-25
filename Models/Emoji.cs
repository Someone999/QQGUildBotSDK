using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models;

public class Emoji
{
    [JsonProperty("id")]
    public string Id { get; set; } = "";
    
    [JsonProperty("type")]
    public EmojiType EmojiType { get; set; }
}