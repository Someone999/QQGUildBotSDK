using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Forum.Post;

public class PostDeletePacketHandler : IPacketHandler
{

    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        ForumPost? forumThread = packet.Data?.ToObject<ForumPost>();
        if (forumThread == null)
        {
            return;
        }
        
        client.EventManager.ForumEvents.ForumPostEvents.OnForumPostCreate?.Invoke(client, new ForumPostEventArgs(client, packet, forumThread));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_POST_DELETE";
}