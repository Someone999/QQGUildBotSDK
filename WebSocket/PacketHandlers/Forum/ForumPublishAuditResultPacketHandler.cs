using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Forum;

public class ForumPublishAuditResultPacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        
        ForumPostAuditResult? forumThread = packet.Data?.ToObject<ForumPostAuditResult>();
        if (forumThread == null)
        {
            return;
        }
        
        client.EventManager.ForumEvents.OnForumPublishAudit?.Invoke(client, new ForumPublishAuditResultArgs(client, packet, forumThread));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_PUBLISH_AUDIT_RESULT";
}