using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

public class ServerPacketBase : IServerPacket<JToken>
{
    [JsonProperty("op")]
    public OperationCode OperationCode { get; set; }
    
    [JsonProperty("d")]
    public JToken? Data{ get; set; }
    
    [JsonProperty("s")]
    public int? Sequence { get; set; }

    object? IServerPacket.Data => Data;

    [JsonProperty("t")]
    public string? SubEventType { get; set; }
}