using QqGuildRobotSdk.WebSocket.Models;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class GuildMemberEventArgs : EventArgBase
{
    public GuildMemberEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, WebSocketMember member) : base(client, packetBase)
    {
        Member = member;
    }
    public WebSocketMember Member { get; }
}