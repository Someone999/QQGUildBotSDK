using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Server;

public class HeartbeatAckPackageHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
    {
    }
    public OperationCode Code => OperationCode.HeartbeatAck;
    public string? SubEventType => null;
    public object? AdditionData => null;
}