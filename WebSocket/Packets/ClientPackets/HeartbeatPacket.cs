using Newtonsoft.Json;

namespace QqChannelRobotSdk.WebSocket.Packets.ClientPackets;

public class HeartbeatPacket : IClientPacket<int?>
{
    public HeartbeatPacket(int? data)
    {
        Data = data;
    }

    [JsonProperty("op")]
    public OperationCode OperationCode => OperationCode.Heartbeat;

    [JsonIgnore]
    public int? Sequence => null;

    [JsonProperty("d")]
    public int? Data { get; set; } 
}