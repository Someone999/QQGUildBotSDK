using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
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
        
        client.EventManager.ForumEvents.ForumReplyEvents.OnForumReplyCreate?.Invoke(client, new ForumReplyEventArgs(client, packet, forumReply));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_REPLY_CREATE";
}