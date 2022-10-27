namespace QqGuildRobotSdk.WebSocket.Packets;

public interface IClientPacket : IPacket
{
}

public interface IClientPacket<TData> : IClientPacket, IPacket<TData>
{
    new TData? Data { get; set; }
}