using Newtonsoft.Json;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ClientPackets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Server;

public class HelloPacketHandler : IPacketHandler
{

    public static object Locker { get; } = new();
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        lock (Locker)
        {
            AuthenticatePacket authenticatePacket = new AuthenticatePacket();
            var identifier = client.Identifier;
            var createParameter = client.ClientInfo.CreateParameters;
            AuthenticatePacketData data = new AuthenticatePacketData
            {
                Token = $"Bot {identifier.BotAppId}.{identifier.BotToken}",
                Shard = new Shard(client.ClientInfo.CurrentShard, createParameter.MaxShardCount ?? 1),
                RegisteredEvents = createParameter.RegisteredEvents
            };
        
            authenticatePacket.Data = data;
        
            if (!client.Connected)
            {
                return;
            }
        
            client.WebSocket.Send(JsonConvert.SerializeObject(authenticatePacket));
        }
    }
    public OperationCode Code => OperationCode.Hello;
    public string? SubEventType => null;
   

}