using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Guild.Channel;

public class DeleteChannelPacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
    {
        WebSocketChannel? channel = packet.Data?.ToObject<WebSocketChannel>();
        if (channel == null)
        {
            return;
        }

        listener.EventManager.GuildEvents.OnChannelDelete?.Invoke(listener, new ChannelEventArgs(channel, packet));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "CHANNEL_DELETE";
}