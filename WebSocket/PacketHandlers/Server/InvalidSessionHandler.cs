using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Server
{
    public class InvalidSessionHandler : IPacketHandler
    {
        public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
        {
            Console.WriteLine($"参数错误: {packet.Data}");
        }

        public OperationCode Code => OperationCode.InvalidSession;
        public string? SubEventType => null;
    }
}
