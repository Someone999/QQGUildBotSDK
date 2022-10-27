using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class MessageCreateEventArgs : EventArgBase
{
    public MessageCreateEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, Message message) : base(client, packetBase)
    {
        Message = message;
    }
    
    public Message Message { get; internal set; }
}