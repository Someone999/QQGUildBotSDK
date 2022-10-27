using QqGuildRobotSdk.Models.Messages;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class MessageAuditEventArgs : EventArgBase
{
    public MessageAuditEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, MessageAudited messageAudited) : base(client, packetBase)
    {
        MessageAudited = messageAudited;
    }
    
    public MessageAudited MessageAudited { get; }
}