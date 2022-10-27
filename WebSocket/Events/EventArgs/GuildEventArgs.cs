using QqGuildRobotSdk.WebSocket.Models;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class GuildEventArgs : EventArgBase
{
    public GuildEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, WebSocketGuild guild) : base(client, packetBase)
    {
        Guild = guild;
    }
    public WebSocketGuild Guild { get; }
}