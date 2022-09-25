using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Guild.DirectMessages;

public class CreateDirectMessagePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketListener listener, ServerPacketBase packet)
    {
        Message? msg = packet.Data?.ToObject<Message>();
        if (msg == null)
        {
            return;
        }

        listener.EventManager.GuildDirectMessageEvents.OnDirectMessageCreate?.Invoke(listener, new MessageCreateEventArgs(packet, msg));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "DIRECT_MESSAGE_CREATE";
}