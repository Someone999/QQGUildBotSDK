using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.MessageAudits
{
    public class MessageAuditPassedPacketHandler : IPacketHandler
    {
        public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
        {
            MessageAudited? msg = packet.Data?.ToObject<MessageAudited>();
            if (msg == null)
            {
                return;
            }
            
            listener.EventManager.MessageAuditEvents.OnMessageAuditPassed?.Invoke(listener, new MessageAuditEventArgs(packet, msg));
        }

        public OperationCode Code => OperationCode.Dispatch;
        public string? SubEventType => "MESSAGE_AUDIT_PASS";
       
    }
}
