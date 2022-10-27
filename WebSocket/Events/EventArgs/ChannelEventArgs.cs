using QqGuildRobotSdk.WebSocket.Models;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class ChannelEventArgs : EventArgBase
{
    public ChannelEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, WebSocketChannel channel) : base(client, packetBase)
    {
        Channel = channel;
    }
    public WebSocketChannel Channel { get; }
}