using Newtonsoft.Json;

namespace QqChannelRobotSdk.Request;

public class MuteSpecifiedMembersRequest : MuteRequest
{
    [JsonProperty("user_ids")]
    public List<string> UserIds { get; set; } = new List<string>();
}