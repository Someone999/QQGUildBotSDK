using Newtonsoft.Json;
using QqChannelRobotSdk.Models.Forums;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Forum;

public class ForumThreadUpdatePacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        ForumThread? forumThread = packet.Data?.ToObject<ForumThread>();
        if (forumThread == null)
        {
            return;
        }
        
        client.EventManager.ForumEvents.ForumThreadEvents.OnForumThreadUpdate?.Invoke(client, new ForumThreadEventArgs(packet, forumThread));
    }

    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "FORUM_THREAD_UPDATE";
}