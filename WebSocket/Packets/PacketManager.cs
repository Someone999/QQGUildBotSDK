﻿using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Packets;

public class PacketManager
{
    public static int[] ValidPacketOpCodes { get; }= new[] {0, 1, 2, 6, 7, 9, 10, 11, 12};
    public IServerPacket? LastPacket { get; internal set; }
    public IServerPacket? LastHasSequencePacket => Packets.LastOrDefault(p => p.Sequence != null);
    public List<IServerPacket> Packets { get; internal set; } = new List<IServerPacket>();

    public ReadyPacketData? LastReadyPacketData
    {
        get
        {
            try
            {
                var packet =
                    Packets.LastOrDefault(p => p.OperationCode == OperationCode.Dispatch && p.SubEventType == "READY");
                return packet is not ServerPacketBase serverPacketBase
                    ? null
                    : serverPacketBase.Data?.ToObject<ReadyPacketData>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            

        }
    }
}