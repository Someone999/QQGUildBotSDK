using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Messages
{
    public class AtMessageCreatePacketHandler : IPacketHandler
    {
        public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
        {
            Message? msg = packet.Data?.ToObject<Message>();
            if (msg == null)
            {
                return;
            }

            var eventData = msg;
            const string eventName = QqGuildEventKeys.AtMessageCreate;
            var e = client.EventManager.GetEvent<QqGuildSdkEvent<MessageCreateEventArgs>>(eventName);
            e?.Raise(new MessageCreateEventArgs(client, packet, eventData));

        }
        public OperationCode Code => OperationCode.Dispatch;
        public string SubEventType => "AT_MESSAGE_CREATE";
        
    }
}
