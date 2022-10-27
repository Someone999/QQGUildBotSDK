using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class MessageDeleteEventArgs : EventArgBase
{
    public MessageDeleteEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, MessageDelete messageDelete) : base(client, packetBase)
    {
        MessageDelete = messageDelete;
    }
    public MessageDelete MessageDelete { get; internal set; }
}