using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
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
        
        var eventData = forumThread;
        const string eventName = QqGuildEventKeys.ForumPublishAuditResult;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<ForumPublishAuditResultArgs>>(eventName);
        e?.Raise(new ForumPublishAuditResultArgs(client, packet, eventData));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_PUBLISH_AUDIT_RESULT";
}