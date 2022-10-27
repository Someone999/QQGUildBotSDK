using QqGuildRobotSdk.WebSocket.Events.EventArgs;

namespace QqGuildRobotSdk.WebSocket.Events;

public class GuildMessageEvents
{
    internal GuildMessageEvents()
    {
    }

    public QqGuildWebSocketEvent<MessageCreateEventArgs>? OnMessageCreate { get; set; }
    public QqGuildWebSocketEvent<MessageDeleteEventArgs>? OnMessageDelete { get; set; }
}