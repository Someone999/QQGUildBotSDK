using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs;

public class ReconnectEventArgs
{
    public ServerPacketBase PacketBase { get; internal set; }
}