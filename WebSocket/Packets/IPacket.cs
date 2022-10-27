namespace QqGuildRobotSdk.WebSocket.Packets;

public interface IPacket
{
    OperationCode OperationCode { get; }
}

public interface IPacket<out TData> : IPacket
{
    TData? Data { get; }
}

public interface IServerPacket<TData> : IServerPacket
{
    new TData? Data { get; set; }
}