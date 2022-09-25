namespace QqChannelRobotSdk.WebSocket.Packets;

public interface IServerPacket : IPacket
{
    string? SubEventType { get; }
    int? Sequence { get; }
    object? Data { get; }
}