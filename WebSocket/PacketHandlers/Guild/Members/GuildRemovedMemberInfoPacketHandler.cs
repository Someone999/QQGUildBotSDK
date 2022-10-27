using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.Models;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Guild.Members;

public class GuildRemovedMemberInfoPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        WebSocketMember? member = packet.Data?.ToObject<WebSocketMember>();
        if (member == null)
        {
            return;
        }
        
        client.EventManager.GuildMemberEvents.OnMemberRemove?.Invoke(client, new GuildMemberEventArgs(client, packet, member));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "GUILD_MEMBER_REMOVE";
}