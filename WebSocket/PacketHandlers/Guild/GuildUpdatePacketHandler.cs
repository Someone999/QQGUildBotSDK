using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Guild;

public class GuildUpdatePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        WebSocketGuild? guild = packet.Data?.ToObject<WebSocketGuild>();
        if (guild == null)
        {
            return;
        }

        client.EventManager.GuildEvents.OnGuildUpdate?.Invoke(client, new GuildEventArgs(packet, guild));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "GUILD_UPDATE";
}