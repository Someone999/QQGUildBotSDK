using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class ForumReplyEventArgs : EventArgBase
{
    public ForumReplyEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, ForumReply forumReply) : base(client, packetBase)
    {
        ForumReply = forumReply;
    }
        
    public ForumReply ForumReply { get; private set; }
}