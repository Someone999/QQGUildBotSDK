using Newtonsoft.Json;
using QqChannelRobotSdk.Models;

namespace QqChannelRobotSdk.WebSocket.Models;

public class WebSocketChannel : Channel
{
    [JsonProperty("op_user_id")]
    public string OperatorUserId { get; } = "";
}