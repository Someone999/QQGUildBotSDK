using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Messages.InteractiveMessages
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
