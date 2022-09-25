using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.WebSocket.Events;

public class GuildMemberEvents
{
    internal GuildMemberEvents()
    {
    }

    public QqGuildWebSocketEvent<GuildMemberEventArgs>? OnMemberAdd { get; set; }
    public QqGuildWebSocketEvent<GuildMemberEventArgs>? OnUpdateMemberInfo { get; set; }
    public QqGuildWebSocketEvent<GuildMemberEventArgs>? OnMemberRemove { get; set; }
    
}