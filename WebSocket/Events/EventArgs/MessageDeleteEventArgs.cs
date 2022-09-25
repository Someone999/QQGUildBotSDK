using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs;

public class MessageDeleteEventArgs
{
    public MessageDeleteEventArgs(ServerPacketBase packetBase, MessageDelete messageDelete)
    {
        PacketBase = packetBase;
        MessageDelete = messageDelete;
    }
    public ServerPacketBase PacketBase { get; internal set; }
    public MessageDelete MessageDelete { get; internal set; }
}