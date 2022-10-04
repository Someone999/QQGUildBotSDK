using QqChannelRobotSdk.Models.Forums;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Forum.Reply;

public class ReplyDeletePacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        ForumReply? forumReply = packet.Data?.ToObject<ForumReply>();
        if (forumReply == null)
        {
            return;
        }
        
        client.EventManager.ForumEvents.ForumReplyEvents.OnForumReplyDelete?.Invoke(client, new ForumReplyEventArgs(packet, forumReply));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_REPLY_DELETE";
}