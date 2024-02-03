using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
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
        
        var eventData = guild;
        const string eventName = QqGuildEventKeys.GuildCreate;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<GuildEventArgs>>(eventName);
        e?.Raise(new GuildEventArgs(client, packet, eventData));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "GUILD_CREATE";
  
}