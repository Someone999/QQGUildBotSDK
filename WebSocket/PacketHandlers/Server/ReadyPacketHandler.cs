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
            Console.WriteLine("建立连接时出现错误");
            return;
        }
        
        client.ClientInfo.SessionId = additionData.SessionId;
        client.ClientInfo.CurrentUser = additionData.User;
        client.ClientInfo.Version = additionData.Version;
        
        Console.WriteLine($"WebSocket{additionData.Shard.Current}已经准备就绪");
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "READY";
}