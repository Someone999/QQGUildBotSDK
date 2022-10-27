using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class ReconnectEventArgs : EventArgBase
{
    public ReconnectEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase) : base(client, packetBase)
    {
    }
}