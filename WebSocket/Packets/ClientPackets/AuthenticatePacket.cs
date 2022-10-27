using Newtonsoft.Json;

namespace QqGuildRobotSdk.WebSocket.Packets.ClientPackets;

public class AuthenticatePacket : IClientPacket<AuthenticatePacketData>
{
    [JsonProperty("op")]
    public OperationCode OperationCode => OperationCode.Identify;

    [JsonIgnore]
    public string? SubEventType => null;

    [JsonIgnore]
    public int? Sequence => null;

    [JsonProperty("d")]
    public AuthenticatePacketData? Data { get; set; }
}