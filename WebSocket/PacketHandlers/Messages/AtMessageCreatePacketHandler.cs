using System.Text.RegularExpressions;
using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.Request;
using QqChannelRobotSdk.Sdk;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Messages
{
    public class AtMessageCreatePacketHandler : IPacketHandler
    {
        public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
        {
            Message? msg = packet.Data?.ToObject<Message>();
            if (msg == null)
            {
                return;
            }

            listener.EventManager.OnCreateAtMessage?.Invoke(listener, new MessageCreateEventArgs(packet, msg));

        }
        public OperationCode Code => OperationCode.Dispatch;
        public string? SubEventType => "AT_MESSAGE_CREATE";
        
    }
}
