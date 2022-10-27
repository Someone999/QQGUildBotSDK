using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
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
        
        client.EventManager.GuildDirectMessageEvents.OnDirectMessageDelete?.Invoke(client, new MessageDeleteEventArgs(client, packet, msg));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "DIRECT_MESSAGE_DELETE";
    
}