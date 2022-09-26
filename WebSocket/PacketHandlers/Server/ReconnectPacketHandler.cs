using Newtonsoft.Json;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ClientPackets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Server;

public class ReconnectPacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        Console.WriteLine("WebSocket意外断开，正在重连");
        var lastReadyPacket = PacketManager.LastReadyPacket;
        if (lastReadyPacket == null)
        {
            Console.WriteLine("因为没有上一个Ready包，无法恢复连接");
            return;
        }
        var resumePacket = new ResumePacket
        {
            Data = new ResumePacketData
            {
                Sequence = packet.Sequence ?? 0,
                Token = client.Identifier.BotAuthToken,
                SessionId = lastReadyPacket.SessionId
            }
        };
        client.WebSocket.Send(JsonConvert.SerializeObject(resumePacket));
        Console.WriteLine("");
    }
    public OperationCode Code => OperationCode.Reconnect;
    public string? SubEventType => null;
    public object? AdditionData => null;
}