using QqGuildRobotSdk.WebSocket.Events.EventArgs;

namespace QqGuildRobotSdk.WebSocket.Events
{
    public class ForumThreadEvents
    {
        public QqGuildWebSocketEvent<ForumThreadEventArgs>? OnForumThreadCreate { get; set; }
        public QqGuildWebSocketEvent<ForumThreadEventArgs>? OnForumThreadUpdate { get; set; }
        public QqGuildWebSocketEvent<ForumThreadEventArgs>? OnForumThreadDelete { get; set; }
    }

    public class ForumPostEvents
    {
        public QqGuildWebSocketEvent<ForumPostEventArgs>? OnForumPostCreate { get; set; }
        public QqGuildWebSocketEvent<ForumPostEventArgs>? OnForumPostDelete { get; set; }
    }
    
    public class ForumReplyEvents
    {
        public QqGuildWebSocketEvent<ForumReplyEventArgs>? OnForumReplyCreate { get; set; }
        public QqGuildWebSocketEvent<ForumReplyEventArgs>? OnForumReplyDelete { get; set; }
    }

    public class ForumEvents
    {
        public ForumThreadEvents ForumThreadEvents { get; } = new ForumThreadEvents();
        public ForumPostEvents ForumPostEvents { get; } = new ForumPostEvents();
        public ForumReplyEvents ForumReplyEvents { get; } = new ForumReplyEvents();
        public QqGuildWebSocketEvent<ForumPublishAuditResultArgs>? OnForumPublishAudit { get; set; }
    }
}
