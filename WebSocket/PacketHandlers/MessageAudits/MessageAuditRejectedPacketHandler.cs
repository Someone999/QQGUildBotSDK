using QqGuildRobotSdk.Models.Messages;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.MessageAudits;

public class MessageAuditRejectedPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        MessageAudited? msg = packet.Data?.ToObject<MessageAudited>();
        if (msg == null)
        {
            return;
        }
        
        client.EventManager.MessageAuditEvents.OnMessageAuditRejected?.Invoke(client, new MessageAuditEventArgs(client, packet, msg));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "MESSAGE_AUDIT_REJECT";
}