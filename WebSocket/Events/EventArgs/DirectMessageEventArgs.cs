using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs;

public class DirectCreateMessageEventArgs : MessageCreateEventArgs
{
    public DirectCreateMessageEventArgs(ServerPacketBase packetBase, Message message) : base(packetBase, message)
    {
    }
}

public class DirectDeleteMessageEventArgs : MessageDeleteEventArgs
{
    public DirectDeleteMessageEventArgs(ServerPacketBase packetBase, MessageDelete messageDelete) : base(packetBase, messageDelete)
    {
    }
}