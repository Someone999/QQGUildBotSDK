using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Messages;

public class MessageCreatePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        Message? msg = packet.Data?.ToObject<Message>();
        if (msg == null)
        {
            return;
        }

        client.EventManager.GuildMessageEvents.OnMessageCreate?.Invoke(client, new MessageCreateEventArgs(client, packet, msg));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "MESSAGE_CREATE";
   
}

