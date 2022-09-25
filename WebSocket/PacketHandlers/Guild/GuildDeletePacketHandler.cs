﻿using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Guild;

public class GuildDeletePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        WebSocketGuild? guild = packet.Data?.ToObject<WebSocketGuild>();
        if (guild == null)
        {
            return;
        }

        client.EventManager.GuildEvents.OnGuildDelete?.Invoke(client, new GuildEventArgs(packet, guild));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "GUILD_DELETE";
   
}