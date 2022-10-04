using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.Models.Messages;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs;

public class MessageAuditEventArgs
{
    public MessageAuditEventArgs(ServerPacketBase packetBase, MessageAudited messageAudited)
    {
        PacketBase = packetBase;
        MessageAudited = messageAudited;
    }
    public ServerPacketBase PacketBase { get; }
    public MessageAudited MessageAudited { get; }
}