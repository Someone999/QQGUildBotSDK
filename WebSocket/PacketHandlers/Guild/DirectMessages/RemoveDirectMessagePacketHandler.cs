using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Guild.DirectMessages;

public class RemoveDirectMessagePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        MessageDelete? msg = packet.Data?.ToObject<MessageDelete>();
        if (msg == null)
        {
            return;
        }
        
        client.EventManager.GuildDirectMessageEvents.OnDirectMessageDelete?.Invoke(client, new MessageDeleteEventArgs(packet, msg));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "DIRECT_MESSAGE_DELETE";
    
}