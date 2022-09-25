using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs;

public class ChannelEventArgs
{
    public ChannelEventArgs(WebSocketChannel channel, ServerPacketBase packetBase)
    {
        Channel = channel;
        PacketBase = packetBase;
    }
    public WebSocketChannel Channel { get; } 
    public ServerPacketBase PacketBase { get; }
}