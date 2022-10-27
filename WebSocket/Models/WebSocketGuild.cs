using Newtonsoft.Json;
using QqGuildRobotSdk.Models;

namespace QqGuildRobotSdk.WebSocket.Models;

public class WebSocketGuild : Guild
{
    [JsonProperty("op_user_id")]
    public string OperatorId { get; private set; } = "";
}