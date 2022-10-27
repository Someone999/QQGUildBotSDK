using Newtonsoft.Json;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ClientPackets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Server;

public class ReconnectPacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        Console.WriteLine("WebSocket意外断开，正在重连");

        var resumePacket = new ResumePacket
        {
            Data = new ResumePacketData
            {
                Sequence = packet.Sequence ?? 0,
                Token = client.Identifier.BotAuthToken,
                SessionId = client.ClientInfo.SessionId
            }
        };
        client.WebSocket.Send(JsonConvert.SerializeObject(resumePacket));
        Console.WriteLine("已发送连接请求");
    }
    public OperationCode Code => OperationCode.Reconnect;
    public string? SubEventType => null;
}