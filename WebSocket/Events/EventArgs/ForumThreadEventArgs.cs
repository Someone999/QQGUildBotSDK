using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs
{
    public class ForumThreadEventArgs : EventArgBase
    {
        public ForumThreadEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, ForumThread forumThread) : base(client, packetBase)
        {
            ForumThread = forumThread;
        }
        
        public ForumThread ForumThread { get; private set; }
    }

    public class ForumPostEventArgs : EventArgBase
    {
        public ForumPostEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, ForumPost forumPost) : base(client, packetBase)
        {
            ForumPost = forumPost;
        }
        
        public ForumPost ForumPost { get; private set; }
    }
    
    public class ForumReplyEventArgs : EventArgBase
    {
        public ForumReplyEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, ForumReply forumReply) : base(client, packetBase)
        {
            ForumReply = forumReply;
        }
        
        public ForumReply ForumReply { get; private set; }
    }
    
    public class ForumPublishAuditResultArgs : EventArgBase
    {
        public ForumPublishAuditResultArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, ForumPostAuditResult auditResult) : base(client, packetBase)
        {
            AuditResult = auditResult;
        }
        
        public ForumPostAuditResult AuditResult { get; private set; }
    }
}
