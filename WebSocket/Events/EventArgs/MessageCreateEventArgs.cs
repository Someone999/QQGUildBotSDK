using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs;

public class MessageCreateEventArgs
{
    public MessageCreateEventArgs(ServerPacketBase packetBase, Message message)
    {
        PacketBase = packetBase;
        Message = message;
    }
    public ServerPacketBase PacketBase { get; internal set; }
    public Message Message { get; internal set; }
}