using Newtonsoft.Json;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ClientPackets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Server;

public class HelloPacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
    {
        //AdditionData = packet.Data?.ToObject<HelloPacketData>();
        AuthenticatePacket authenticatePacket = new AuthenticatePacket();
        var identifier = listener.Identifier;
        AuthenticatePacketData data = new AuthenticatePacketData
        {
            Token = $"Bot {identifier.BotAppId}.{identifier.BotToken}",
            Shard = Shard.OneShard,
            RegisteredEvents = listener.RegisteredEvent
        };
        authenticatePacket.Data = data;
        
        if (!listener.Connected)
        {
            return;
        }
        
        listener.WebSocket.Send(JsonConvert.SerializeObject(authenticatePacket));
    }
    public OperationCode Code => OperationCode.Hello;
    public string? SubEventType => null;
   

}