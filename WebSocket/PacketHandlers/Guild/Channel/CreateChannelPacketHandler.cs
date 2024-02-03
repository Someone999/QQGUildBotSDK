using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.Models;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Guild.Channel;

public class CreateChannelPacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        WebSocketChannel? channel = packet.Data?.ToObject<WebSocketChannel>();
        if (channel == null)
        {
            return;
        }

        var eventData = channel;
        const string eventName = QqGuildEventKeys.GuildChannelCreate;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<ChannelEventArgs>>(eventName);
        e?.Raise(new ChannelEventArgs(client, packet, eventData));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "CHANNEL_CREATE";
}