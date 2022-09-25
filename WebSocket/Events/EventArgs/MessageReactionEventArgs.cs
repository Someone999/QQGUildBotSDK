using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs;

public class MessageReactionEventArgs
{
    public MessageReactionEventArgs(ServerPacketBase packetBase, MessageReaction messageReaction)
    {
        PacketBase = packetBase;
        MessageReaction = messageReaction;
    }
    public ServerPacketBase PacketBase { get; }
    public MessageReaction MessageReaction { get; }
}