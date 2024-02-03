using QqGuildRobotSdk.Messages.MessageReaction;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Guild.MessageReactions;

public class RemoveMessageReactionPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        MessageReaction? messageReaction = packet.Data?.ToObject<MessageReaction>();
        if (messageReaction == null)
        {
            return;
        }

        var eventData = messageReaction;
        const string eventName = QqGuildEventKeys.GuildMessageReactionRemove;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<MessageReactionEventArgs>>(eventName);
        e?.Raise(new MessageReactionEventArgs(client, packet, eventData));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "MESSAGE_REACTION_REMOVE";
   
}