using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Guild.Members;

public class GuildJoinedMemberPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
    {
        WebSocketMember? member = packet.Data?.ToObject<WebSocketMember>();
        if (member == null)
        {
            return;
        }
            
        listener.EventManager.GuildMemberEvents.OnMemberAdd?.Invoke(listener, new GuildMemberEventArgs(packet, member));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "GUILD_MEMBER_ADD";
}