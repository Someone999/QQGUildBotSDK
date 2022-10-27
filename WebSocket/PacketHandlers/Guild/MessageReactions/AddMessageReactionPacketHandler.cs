using QqGuildRobotSdk.Messages.MessageReaction;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

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

            client.EventManager
                .GuildMessageReactionEvents
                .OnCreateMessageReaction?
                .Invoke(client, new MessageReactionEventArgs(client, packet, messageReaction));
        }

        public OperationCode Code => OperationCode.Dispatch;
        public string SubEventType => "MESSAGE_REACTION_ADD";
       
    }
}
