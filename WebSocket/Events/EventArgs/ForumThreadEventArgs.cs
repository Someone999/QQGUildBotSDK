using QqChannelRobotSdk.Models.Forums;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs
{
    public class ForumThreadEventArgs
    {
        public ForumThreadEventArgs(ServerPacketBase packetBase, ForumThread forumThread)
        {
            PacketBase = packetBase;
            ForumThread = forumThread;
        }

        public ServerPacketBase PacketBase { get; set; }
        public ForumThread ForumThread { get; private set; }
    }

    public class ForumPostEventArgs
    {
        public ForumPostEventArgs(ServerPacketBase packetBase, ForumPost forumPost)
        {
            PacketBase = packetBase;
            ForumPost = forumPost;
        }

        public ServerPacketBase PacketBase { get; set; }
        public ForumPost ForumPost { get; private set; }
    }
    
    public class ForumReplyEventArgs
    {
        public ForumReplyEventArgs(ServerPacketBase packetBase, ForumReply forumReply)
        {
            PacketBase = packetBase;
            ForumReply = forumReply;
        }

        public ServerPacketBase PacketBase { get; set; }
        public ForumReply ForumReply { get; private set; }
    }
    
    public class ForumPublishAuditResultArgs
    {
        public ForumPublishAuditResultArgs(ServerPacketBase packetBase, ForumPostAuditResult auditResult)
        {
            PacketBase = packetBase;
            AuditResult = auditResult;
        }

        public ServerPacketBase PacketBase { get; set; }
        public ForumPostAuditResult AuditResult { get; private set; }
    }
}
