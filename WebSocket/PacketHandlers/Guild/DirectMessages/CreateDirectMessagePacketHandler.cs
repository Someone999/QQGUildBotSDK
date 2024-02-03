using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
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

        var eventData = msg;
        const string eventName = QqGuildEventKeys.GuildDirectMessageCreate;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<DirectCreateMessageEventArgs>>(eventName);
        e?.Raise(new DirectCreateMessageEventArgs(client, packet, eventData));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "DIRECT_MESSAGE_CREATE";
}