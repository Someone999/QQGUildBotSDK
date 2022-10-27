using Newtonsoft.Json;
using QqGuildRobotSdk.JsonConverters;
using QqGuildRobotSdk.WebSocket.Models;
using QqGuildRobotSdk.WebSocket.Packets.ClientPackets;

namespace QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

public class ReadyPacketData
{
    [JsonProperty("version")]
    public int Version { get; private set; }

    [JsonProperty("session_id")]
    public string SessionId { get; private set; } = "";
    
    [JsonProperty("user")]
    public WebSocketUser User { get; private set; } = WebSocketUser.Empty;
    
    [JsonProperty("shard")]
    [JsonConverter(typeof(ShardJsonConverter))]
    public Shard Shard { get; set; } = Shard.None;
}