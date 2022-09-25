using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs;

public class InteractionEventArgs
{
    public InteractionEventArgs(ServerPacketBase packetBase)
    {
        PacketBase = packetBase;
    }
    public ServerPacketBase PacketBase { get; internal set; }
}