using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class DirectDeleteMessageEventArgs : MessageDeleteEventArgs
{
    public DirectDeleteMessageEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, MessageDelete messageDelete) : base(client, packetBase, messageDelete)
    {
    }
}