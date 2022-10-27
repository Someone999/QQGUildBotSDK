using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public abstract class EventArgBase
{
    protected EventArgBase(QqGuildWebSocketClient client, ServerPacketBase packetBase)
    {
        PacketBase = packetBase;
        Client = client;
    }
    
    public ServerPacketBase PacketBase { get; protected set; }
    public QqGuildWebSocketClient Client { get; protected set; }
}