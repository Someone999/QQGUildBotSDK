using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.MessageAudits;

public class MessageAuditRejectedPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
    {
        MessageAudited? msg = packet.Data?.ToObject<MessageAudited>();
        if (msg == null)
        {
            return;
        }
        
        listener.EventManager.MessageAuditEvents.OnMessageAuditRejected?.Invoke(listener, new MessageAuditEventArgs(packet, msg));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "MESSAGE_AUDIT_REJECT";
}