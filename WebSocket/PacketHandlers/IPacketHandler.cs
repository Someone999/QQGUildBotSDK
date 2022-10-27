using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers;


public interface IPacketHandler
{
    void Handle(QqGuildWebSocketClient client, ServerPacketBase packet);
    OperationCode Code { get; }
    string? SubEventType { get; }
}
