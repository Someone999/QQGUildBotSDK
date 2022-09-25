using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.WebSocket.Events;

public class GuildMessageEvents
{
    internal GuildMessageEvents()
    {
    }

    public QqGuildWebSocketEvent<MessageCreateEventArgs>? OnMessageCreate { get; set; }
    public QqGuildWebSocketEvent<MessageDeleteEventArgs>? OnMessageDelete { get; set; }
}