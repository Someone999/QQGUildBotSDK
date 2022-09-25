using Newtonsoft.Json;

namespace QqChannelRobotSdk.WebSocket.Packets.ClientPackets;

public class ResumePacket : IClientPacket<ResumePacketData>
{
    [JsonProperty("op")]
    public OperationCode OperationCode => OperationCode.Resume;

    [JsonIgnore]
    public string? SubEventType => null;

    [JsonIgnore]
    public int? Sequence => null;

    [JsonProperty("d")]
    public ResumePacketData? Data { get; set; }
}