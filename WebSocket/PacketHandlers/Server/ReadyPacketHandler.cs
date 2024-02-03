using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.EventSystem.Events;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Server;

public class ReadyPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    { 
        var additionData = packet.Data?.ToObject<ReadyPacketData>();
        if (additionData == null)
        {
            client.EventManager.GetEvent<GenericEvent<PacketReceivedEventArgs>>(QqGuildEventKeys.WebSocketFailed);
            return;
        }
        
        client.ClientInfo.SessionId = additionData.SessionId;
        client.ClientInfo.CurrentUser = additionData.User;
        client.ClientInfo.Version = additionData.Version;
        
        client.EventManager.GetEvent<GenericEvent<ReadyPacketData>>(QqGuildEventKeys.WebSocketReadied);
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "READY";
}