using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.Models;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Guild.Members;

public class GuildJoinedMemberPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        WebSocketMember? member = packet.Data?.ToObject<WebSocketMember>();
        if (member == null)
        {
            return;
        }
            
        var eventData = member;
        const string eventName = QqGuildEventKeys.GuildMemberJoined;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<GuildMemberEventArgs>>(eventName);
        e?.Raise(new GuildMemberEventArgs(client, packet, eventData));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "GUILD_MEMBER_ADD";
}