using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs;

public class GuildEventArgs
{
    public GuildEventArgs(ServerPacketBase packetBase, WebSocketGuild guild)
    {
        PacketBase = packetBase;
        Guild = guild;
    }
    public ServerPacketBase PacketBase { get; }
    public WebSocketGuild Guild { get; }
}