using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class InteractionEventArgs : EventArgBase
{
    public InteractionEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase) : base(client, packetBase)
    {
    }
}