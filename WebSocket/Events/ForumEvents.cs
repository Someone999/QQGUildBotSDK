using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.WebSocket.Events
{
    public class ForumThreadEvents
    {
        public QqGuildWebSocketEvent<ForumThreadEventArgs>? OnForumThreadCreate { get; set; }
        public QqGuildWebSocketEvent<ForumThreadEventArgs>? OnForumThreadUpdate { get; set; }
        public QqGuildWebSocketEvent<ForumThreadEventArgs>? OnForumThreadDelete { get; set; }
    }

    public class ForumPostEvents
    {
    }

    public class ForumEvents
    {
    }
}
