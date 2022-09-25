using Newtonsoft.Json;
using QqChannelRobotSdk.JsonConverters;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets.ClientPackets;

namespace QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

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
    public Shard Shard { get; set; }= Shard.None;
}