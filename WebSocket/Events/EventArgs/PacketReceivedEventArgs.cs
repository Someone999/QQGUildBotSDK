using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class PacketReceivedEventArgs : EventArgBase
{
    public PacketReceivedEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase) : base(client, packetBase)
    {
    }
}