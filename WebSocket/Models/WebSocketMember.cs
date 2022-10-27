using Newtonsoft.Json;
using QqGuildRobotSdk.Models.Members;

namespace QqGuildRobotSdk.WebSocket.Models
{
    public class WebSocketMember : MemberWithGuildId
    {
        [JsonProperty("op_user_id")] public string OperatorId { get; set; } = "";
    }
}
