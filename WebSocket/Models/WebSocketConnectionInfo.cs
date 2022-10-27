using Newtonsoft.Json;

namespace QqGuildRobotSdk.WebSocket.Models;

public class WebSocketConnectionInfo
{
    [JsonProperty("url")]
    public string Url { get; private set; } = "";
}