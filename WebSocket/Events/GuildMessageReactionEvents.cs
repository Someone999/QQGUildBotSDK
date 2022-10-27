using QqGuildRobotSdk.WebSocket.Events.EventArgs;

namespace QqGuildRobotSdk.WebSocket.Events;

public class GuildMessageReactionEvents
{
    internal GuildMessageReactionEvents()
    {
    }

    public QqGuildWebSocketEvent<MessageReactionEventArgs>? OnCreateMessageReaction { get; set; }
    public QqGuildWebSocketEvent<MessageReactionEventArgs>? OnRemoveMessageReaction { get; set; }
}