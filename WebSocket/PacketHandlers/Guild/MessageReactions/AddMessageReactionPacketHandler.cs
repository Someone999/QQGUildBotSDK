using QqGuildRobotSdk.Messages.MessageReaction;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;
using WebSocket4Net;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Guild.MessageReactions
{
    public class AddMessageReactionPacketHandler : IPacketHandler
    {
        public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
        {
            MessageReaction? messageReaction = packet.Data?.ToObject<MessageReaction>();
            if (messageReaction == null)
            {
                return;
            }

            var eventData = messageReaction;
            const string eventName = QqGuildEventKeys.GuildMessageReactionAdd;
            var e = client.EventManager.GetEvent<QqGuildSdkEvent<MessageReactionEventArgs>>(eventName);
            e?.Raise(new MessageReactionEventArgs(client, packet, eventData));
        }

        public OperationCode Code => OperationCode.Dispatch;
        public string SubEventType => "MESSAGE_REACTION_ADD";
       
    }
}
