using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.WebSocket.Events;

public class GuildDirectMessageEvents
{
    internal GuildDirectMessageEvents()
    {
    }

    public QqGuildWebSocketEvent<MessageCreateEventArgs>? OnDirectMessageCreate { get; set; }
    public QqGuildWebSocketEvent<MessageDeleteEventArgs>? OnDirectMessageDelete { get; set; }
}