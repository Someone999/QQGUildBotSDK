using Newtonsoft.Json;
using QqChannelRobotSdk.Models;

namespace QqChannelRobotSdk.WebSocket.Models;

public class WebSocketGuild : Guild
{
    [JsonProperty("op_user_id")]
    public string OperatorId { get; private set; } = "";
}