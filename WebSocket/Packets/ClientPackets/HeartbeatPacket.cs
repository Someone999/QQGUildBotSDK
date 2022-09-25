using Newtonsoft.Json;

namespace QqChannelRobotSdk.WebSocket.Packets.ClientPackets;

public class HeartbeatPacket : IClientPacket<int?>
{
    [JsonProperty("op")]
    public OperationCode OperationCode => OperationCode.Heartbeat;

    [JsonIgnore]
    public int? Sequence => null;

    [JsonProperty("d")]
    public int? Data { get; set; } = PacketManager.LastHasSequencePacket?.Sequence;
}