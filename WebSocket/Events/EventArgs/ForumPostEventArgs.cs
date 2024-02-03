using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class ForumPostEventArgs : EventArgBase
{
    public ForumPostEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, ForumPost forumPost) : base(client, packetBase)
    {
        ForumPost = forumPost;
    }
        
    public ForumPost ForumPost { get; private set; }
}