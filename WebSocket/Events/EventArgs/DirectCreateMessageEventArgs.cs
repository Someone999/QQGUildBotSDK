using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class DirectCreateMessageEventArgs : MessageCreateEventArgs
{
    public DirectCreateMessageEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, Message message) : base(client, packetBase, message)
    {
    }
}