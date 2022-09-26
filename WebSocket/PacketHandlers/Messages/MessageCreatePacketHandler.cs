using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.Request;
using QqChannelRobotSdk.Sdk;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Messages;

public class MessageCreatePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        Message? msg = packet.Data?.ToObject<Message>();
        if (msg == null)
        {
            return;
        }

        client.EventManager.GuildMessageEvents.OnMessageCreate?.Invoke(client, new MessageCreateEventArgs(packet, msg));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string SubEventType => "MESSAGE_CREATE";
   
}

