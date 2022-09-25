using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.WebSocket.Events;

public class GuildMessageReactionEvents
{
    internal GuildMessageReactionEvents()
    {
    }

    public QqGuildWebSocketEvent<MessageReactionEventArgs>? OnCreateMessageReaction { get; set; }
    public QqGuildWebSocketEvent<MessageReactionEventArgs>? OnRemoveMessageReaction { get; set; }
}