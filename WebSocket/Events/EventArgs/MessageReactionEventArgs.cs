using QqGuildRobotSdk.Messages.MessageReaction;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class MessageReactionEventArgs : EventArgBase
{
    public MessageReactionEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, MessageReaction messageReaction) : base(client, packetBase)
    {
        MessageReaction = messageReaction;
    }
    public MessageReaction MessageReaction { get; }
}