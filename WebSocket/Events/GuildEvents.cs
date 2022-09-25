using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.WebSocket.Events;

public class GuildEvents
{
    internal GuildEvents()
    {
    }

    public QqGuildWebSocketEvent<GuildEventArgs>? OnGuildCreate { get; set; }
    public QqGuildWebSocketEvent<GuildEventArgs>? OnGuildUpdate { get; set; }
    public QqGuildWebSocketEvent<GuildEventArgs>? OnGuildDelete { get; set; }
    public QqGuildWebSocketEvent<ChannelEventArgs>? OnChannelCreate { get; set; }
    public QqGuildWebSocketEvent<ChannelEventArgs>? OnChannelUpdate { get; set; }
    public QqGuildWebSocketEvent<ChannelEventArgs>? OnChannelDelete { get; set; }
}