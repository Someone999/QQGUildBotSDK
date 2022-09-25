using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

public class ServerPacketBase : IServerPacket<JObject>
{
    [JsonProperty("op")]
    public OperationCode OperationCode { get; set; }
    
    [JsonProperty("d")]
    public JObject? Data{ get; set; }
    
    [JsonProperty("s")]
    public int? Sequence { get; set; }

    object? IServerPacket.Data => Data;

    [JsonProperty("t")]
    public string? SubEventType { get; set; }
}