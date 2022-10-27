using Newtonsoft.Json;
using QqGuildRobotSdk.JsonConverters;
using QqGuildRobotSdk.WebSocket.Models;

namespace QqGuildRobotSdk.WebSocket.Packets.ClientPackets;

public class AuthenticatePacketData
{
    [JsonProperty("token")]
    public string Token { get; set; } = "";
    
    [JsonProperty("intents")]
    public PrimaryEventType RegisteredEvents { get; set; }

    [JsonProperty("shard")]
    [JsonConverter(typeof(ShardJsonConverter))]
    public Shard Shard { get; set; } = Shard.OneShard;
}