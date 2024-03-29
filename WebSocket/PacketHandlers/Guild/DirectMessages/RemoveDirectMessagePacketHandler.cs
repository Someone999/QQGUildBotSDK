﻿using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Guild.DirectMessages;

public class RemoveDirectMessagePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        MessageDelete? msg = packet.Data?.ToObject<MessageDelete>();
        if (msg == null)
        {
            return;
        }
        
        var eventData = msg;
        const string eventName = QqGuildEventKeys.GuildDirectMessageRemove;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<DirectDeleteMessageEventArgs>>(eventName);
        e?.Raise(new DirectDeleteMessageEventArgs(client, packet, eventData));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "DIRECT_MESSAGE_DELETE";
    
}