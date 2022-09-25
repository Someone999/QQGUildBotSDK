using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs;

public class GuildMemberEventArgs
{
    public GuildMemberEventArgs(ServerPacketBase packetBase, WebSocketMember member)
    {
        PacketBase = packetBase;
        Member = member;
    }
    public ServerPacketBase PacketBase { get; }
    public WebSocketMember Member { get; }
}