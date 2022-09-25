﻿using Newtonsoft.Json;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ClientPackets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Server;

public class ReconnectPacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
    {
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
                Token = listener.Identifier.BotAuthToken,
                SessionId = lastReadyPacket.SessionId
            }
        };
        listener.WebSocket.Send(JsonConvert.SerializeObject(resumePacket));
    }
    public OperationCode Code => OperationCode.Reconnect;
    public string? SubEventType => null;
    public object? AdditionData => null;
}