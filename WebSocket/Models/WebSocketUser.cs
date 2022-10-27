using Newtonsoft.Json;

namespace QqGuildRobotSdk.WebSocket.Models;

public class WebSocketUser
{
    [JsonProperty("id")]
    public string Id { get; set; } = "";

    [JsonProperty("username")]
    public string UserName { get; set; } = "";

    [JsonProperty("bot")]
    public bool IsBot { get; set; }

    public static WebSocketUser Empty { get; } = new();
}