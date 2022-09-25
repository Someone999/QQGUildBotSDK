using Newtonsoft.Json;
using QqChannelRobotSdk.JsonConverters;
using QqChannelRobotSdk.WebSocket.Models;

namespace QqChannelRobotSdk.WebSocket.Packets.ClientPackets;

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