using Newtonsoft.Json.Linq;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Packets;

public static class PacketManager
{
    public static int[] ValidPacketOpCodes { get; }= new[] {0, 1, 2, 6, 7, 9, 10, 11, 12};
    public static IServerPacket? LastPacket { get; internal set; }
    public static IServerPacket? LastHasSequencePacket => Packets.LastOrDefault(p => p.Sequence != null);
    public static List<IServerPacket> Packets { get; internal set; } = new List<IServerPacket>();

    public static ReadyPacketData? LastReadyPacket
    {
        get
        {
            var packet =
                Packets.LastOrDefault(p => p.OperationCode == OperationCode.Dispatch && p.SubEventType == "READY");
            if (packet is not ServerPacketBase serverPacketBase)
            {
                return null;
            }

            return serverPacketBase.Data?.ToObject<ReadyPacketData>();
        }
    }
        
    internal static object Locker { get; } = new object();
}