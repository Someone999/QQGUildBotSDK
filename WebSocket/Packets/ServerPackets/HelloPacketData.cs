using Newtonsoft.Json;

namespace QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

public class HelloPacketData
{
    [JsonProperty("heartbeat_interval")]
    public int HeartbeatInterval { get; internal set; }
}