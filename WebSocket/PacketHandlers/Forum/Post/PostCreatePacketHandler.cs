using QqChannelRobotSdk.Models.Forums;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Forum.Post;

public class PostCreatePacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        ForumPost? forumThread = packet.Data?.ToObject<ForumPost>();
        if (forumThread == null)
        {
            return;
        }
        
        client.EventManager.ForumEvents.ForumPostEvents.OnForumPostCreate?.Invoke(client, new ForumPostEventArgs(packet, forumThread));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_POST_CREATE";
}


