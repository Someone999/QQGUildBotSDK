using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Server;

public class ReadyPacketHandler : IPacketHandler
{
    private ReadyPacketData? _additionData;
    public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
    {
        //AdditionData = packet.Data?.ToObject<ReadyPacketData>();
        Console.WriteLine("WebSocket已经准备就绪");
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "READY";
   

}