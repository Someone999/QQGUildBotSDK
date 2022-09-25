using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers;


public interface IPacketHandler
{
    void Handle(QqGuildWebSocketClient client, ServerPacketBase packet);
    OperationCode Code { get; }
    string? SubEventType { get; }
}
