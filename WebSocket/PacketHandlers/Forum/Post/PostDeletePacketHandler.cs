using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
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
        
        var eventData = forumThread;
        const string eventName = QqGuildEventKeys.ForumPostDelete;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<ForumPostEventArgs>>(eventName);
        e?.Raise(new ForumPostEventArgs(client, packet, eventData));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_POST_DELETE";
}