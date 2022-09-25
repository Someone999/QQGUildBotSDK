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
        public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
        {
            Message? msg = packet.Data?.ToObject<Message>();
            if (msg == null)
            {
                return;
            }

            client.EventManager.OnCreateAtMessage?.Invoke(client, new MessageCreateEventArgs(packet, msg));

        }
        public OperationCode Code => OperationCode.Dispatch;
        public string? SubEventType => "AT_MESSAGE_CREATE";
        
    }
}
