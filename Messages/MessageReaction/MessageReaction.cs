using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.MessageReaction;

public class MessageReaction
{
    [JsonProperty("user_id")] 
    public string UserId { get; set; } = "";
    
    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = "";

    [JsonProperty("channel_id")]
    public string ChannelId { get; set; } = "";

    [JsonProperty("target")]
    public ReactionTarget Target { get; set; } = ReactionTarget.Empty;
}