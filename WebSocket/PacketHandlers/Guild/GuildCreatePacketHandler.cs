﻿using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Guild;

public class GuildCreatePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
    {
        WebSocketGuild? guild = packet.Data?.ToObject<WebSocketGuild>();
        if (guild == null)
        {
            return;
        }
        
        listener.EventManager.GuildEvents.OnGuildCreate?.Invoke(listener, new GuildEventArgs(packet, guild));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "GUILD_CREATE";
  
}