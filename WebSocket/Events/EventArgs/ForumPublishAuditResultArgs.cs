using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class ForumPublishAuditResultArgs : EventArgBase
{
    public ForumPublishAuditResultArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, ForumPostAuditResult auditResult) : base(client, packetBase)
    {
        AuditResult = auditResult;
    }
        
    public ForumPostAuditResult AuditResult { get; private set; }
}