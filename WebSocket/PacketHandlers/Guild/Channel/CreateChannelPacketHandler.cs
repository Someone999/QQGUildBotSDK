using QqGuildRobotSdk.WebSocket.Events.EventArgs;
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

        client.EventManager.GuildEvents.OnChannelCreate?.Invoke(client, new ChannelEventArgs(client, packet, channel));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "CHANNEL_CREATE";
}