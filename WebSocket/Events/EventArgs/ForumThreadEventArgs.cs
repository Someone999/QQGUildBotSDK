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
}
