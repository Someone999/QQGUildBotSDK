using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Server
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
