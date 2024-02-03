using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Messages;

public class MessageDeletePackageHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        MessageDelete? msgDelete = packet.Data?.ToObject<MessageDelete>();
        if (msgDelete == null)
        {
            return;
        }

       
        var eventData = msgDelete;
        const string eventName = QqGuildEventKeys.MessageDelete;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<MessageDeleteEventArgs>>(eventName);
        e?.Raise(new MessageDeleteEventArgs(client, packet, eventData));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "MESSAGE_DELETE";
    
}