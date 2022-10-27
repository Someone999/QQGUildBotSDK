using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.Models;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Guild;

public class GuildCreatePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        WebSocketGuild? guild = packet.Data?.ToObject<WebSocketGuild>();
        if (guild == null)
        {
            return;
        }
        
        client.EventManager.GuildEvents.OnGuildCreate?.Invoke(client, new GuildEventArgs(client, packet, guild));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "GUILD_CREATE";
  
}