using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Forum;

public class ForumThreadUpdatePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        ForumThread? forumThread = packet.Data?.ToObject<ForumThread>();
        if (forumThread == null)
        {
            return;
        }
        
        client.EventManager.ForumEvents.ForumThreadEvents.OnForumThreadUpdate?.Invoke(client, new ForumThreadEventArgs(client, packet, forumThread));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_THREAD_UPDATE";
}