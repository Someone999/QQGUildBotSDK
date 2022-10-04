using QqChannelRobotSdk.Models.Forums;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Forum;

public class ForumPublishAuditResultPacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        
        ForumPostAuditResult? forumThread = packet.Data?.ToObject<ForumPostAuditResult>();
        if (forumThread == null)
        {
            return;
        }
        
        client.EventManager.ForumEvents.OnForumPublishAudit?.Invoke(client, new ForumPublishAuditResultArgs(packet, forumThread));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_PUBLISH_AUDIT_RESULT";
}