using Newtonsoft.Json;
using QqGuildRobotSdk.Models.Channels;

namespace QqGuildRobotSdk.WebSocket.Models;

public class WebSocketChannel : Channel
{
    [JsonProperty("op_user_id")]
    public string OperatorUserId { get; } = "";
}