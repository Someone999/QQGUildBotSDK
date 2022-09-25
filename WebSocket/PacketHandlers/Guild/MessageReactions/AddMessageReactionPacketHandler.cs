using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Guild.MessageReactions
{
    public class AddMessageReactionPacketHandler : IPacketHandler
    {
        public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
        {
            MessageReaction? messageReaction = packet.Data?.ToObject<MessageReaction>();
            if (messageReaction == null)
            {
                return;
            }

            listener.EventManager
                .GuildMessageReactionEvents
                .OnCreateMessageReaction?
                .Invoke(listener, new MessageReactionEventArgs(packet, messageReaction));
        }

        public OperationCode Code => OperationCode.Dispatch;
        public string? SubEventType => "MESSAGE_REACTION_ADD";
       
    }
}
