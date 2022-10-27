using Newtonsoft.Json;

namespace QqGuildRobotSdk.Request;

public class MuteSpecifiedMembersRequest : MuteRequest
{
    [JsonProperty("user_ids")]
    public List<string> UserIds { get; set; } = new List<string>();
}