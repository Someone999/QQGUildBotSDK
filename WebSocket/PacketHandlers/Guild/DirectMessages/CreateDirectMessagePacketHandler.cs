using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Guild.DirectMessages;

public class CreateDirectMessagePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        Message? msg = packet.Data?.ToObject<Message>();
        if (msg == null)
        {
            return;
        }

        client.EventManager.GuildDirectMessageEvents.OnDirectMessageCreate?.Invoke(client, new MessageCreateEventArgs(client, packet, msg));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "DIRECT_MESSAGE_CREATE";
}