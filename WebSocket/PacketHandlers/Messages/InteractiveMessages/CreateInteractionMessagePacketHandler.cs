using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Messages.InteractiveMessages
{
    internal class CreateInteractionMessagePacketHandler : IPacketHandler
    {
        public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
        {
            Console.WriteLine("[PackHandler::CreateInteractionMessage] 目前无法确定该事件的结构，暂不处理");
            //Console.WriteLine(packet.Data);
        }

        public OperationCode Code => OperationCode.Dispatch;
        public string SubEventType => "INTERACTION_CREATE";
    }
}
