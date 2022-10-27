using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.Models;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Guild.Members;

public class GuildUpdatedMemberInfoPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        WebSocketMember? member = packet.Data?.ToObject<WebSocketMember>();
        if (member == null)
        {
            return;
        }
        
        client.EventManager.GuildMemberEvents.OnUpdateMemberInfo?.Invoke(client, new GuildMemberEventArgs(client, packet, member));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "GUILD_MEMBER_UPDATE";
}