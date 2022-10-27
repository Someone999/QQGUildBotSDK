using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
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

       
        client.EventManager.GuildMessageEvents.OnMessageDelete?.Invoke(client, new MessageDeleteEventArgs(client, packet, msgDelete));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "MESSAGE_DELETE";
    
}