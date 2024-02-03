using QqGuildRobotSdk.Models.Messages;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
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
        
        var eventData = msg;
        const string eventName = QqGuildEventKeys.MessageAuditRejected;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<MessageAuditEventArgs>>(eventName);
        e?.Raise(new MessageAuditEventArgs(client, packet, eventData));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "MESSAGE_AUDIT_REJECT";
}