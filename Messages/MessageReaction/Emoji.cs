using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.MessageReaction;

public class Emoji
{
    [JsonProperty("id")]
    public string Id { get; set; } = "";
    
    [JsonProperty("type")]
    public EmojiType EmojiType { get; set; }
}