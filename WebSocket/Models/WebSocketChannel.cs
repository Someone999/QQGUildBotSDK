using Newtonsoft.Json;
using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.Models.Channels;

namespace QqChannelRobotSdk.WebSocket.Models;

public class WebSocketChannel : Channel
{
    [JsonProperty("op_user_id")]
    public string OperatorUserId { get; } = "";
}