using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
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
        
        var eventData = forumThread;
        const string eventName = QqGuildEventKeys.ForumThreadUpdate;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<ForumThreadEventArgs>>(eventName);
        e?.Raise(new ForumThreadEventArgs(client, packet, eventData));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_THREAD_UPDATE";
}