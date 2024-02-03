using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Forum.Reply;

public class ReplyCreatePacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        ForumReply? forumReply = packet.Data?.ToObject<ForumReply>();
        if (forumReply == null)
        {
            return;
        }
        
        var eventData = forumReply;
        const string eventName = QqGuildEventKeys.ForumReplyCreate;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<ForumReplyEventArgs>>(eventName);
        e?.Raise(new ForumReplyEventArgs(client, packet, eventData));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_REPLY_CREATE";
}