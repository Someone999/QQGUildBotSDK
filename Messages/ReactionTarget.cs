using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages;

public class ReactionTarget
{
    [JsonProperty("id")] 
    public string Id { get; set; } = "";

    [JsonProperty("type")] 
    public ReactionTargetType TargetType { get; set; } = ReactionTargetType.None;

    public static ReactionTarget Empty { get; } = new ReactionTarget();
}