using QqGuildRobotSdk.WebSocket.Events.EventArgs;

namespace QqGuildRobotSdk.WebSocket.Events;

public class GuildMemberEvents
{
    internal GuildMemberEvents()
    {
    }

    public QqGuildWebSocketEvent<GuildMemberEventArgs>? OnMemberAdd { get; set; }
    public QqGuildWebSocketEvent<GuildMemberEventArgs>? OnUpdateMemberInfo { get; set; }
    public QqGuildWebSocketEvent<GuildMemberEventArgs>? OnMemberRemove { get; set; }
    
}