using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Server
{
    public class ResumePacketHandler : IPacketHandler
    {
        public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
        {
            Console.WriteLine("已恢复连接");
        }

        public OperationCode Code => OperationCode.Dispatch;
        public string SubEventType => "RESUMED";
    }
}
