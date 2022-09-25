using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Guild.Channel;

public class CreateChannelPacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        WebSocketChannel? channel = packet.Data?.ToObject<WebSocketChannel>();
        if (channel == null)
        {
            return;
        }

        client.EventManager.GuildEvents.OnChannelCreate?.Invoke(client, new ChannelEventArgs(channel, packet));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "CHANNEL_CREATE";
}