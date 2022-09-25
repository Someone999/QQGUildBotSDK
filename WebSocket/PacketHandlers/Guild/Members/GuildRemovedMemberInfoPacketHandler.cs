using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Guild.Members;

public class GuildRemovedMemberInfoPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        WebSocketMember? member = packet.Data?.ToObject<WebSocketMember>();
        if (member == null)
        {
            return;
        }
        
        client.EventManager.GuildMemberEvents.OnMemberRemove?.Invoke(client, new GuildMemberEventArgs(packet, member));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "GUILD_MEMBER_REMOVE";
}