using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Messages;

public class MessageDeletePackageHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
    {
        MessageDelete? msgDelete = packet.Data?.ToObject<MessageDelete>();
        if (msgDelete == null)
        {
            return;
        }

       
        listener.EventManager.GuildMessageEvents.OnMessageDelete?.Invoke(listener, new MessageDeleteEventArgs(packet, msgDelete));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "MESSAGE_DELETE";
    
}