using QqGuildRobotSdk.WebSocket.Events.EventArgs;

namespace QqGuildRobotSdk.WebSocket.Events;

public class EventManager
{
    internal EventManager()
    {
    }
    public GuildEvents GuildEvents { get; } = new GuildEvents();
    public GuildMemberEvents GuildMemberEvents { get; } = new GuildMemberEvents();
    public GuildMessageEvents GuildMessageEvents { get; } = new GuildMessageEvents();
    public GuildMessageReactionEvents GuildMessageReactionEvents { get; } = new GuildMessageReactionEvents();
    public GuildDirectMessageEvents GuildDirectMessageEvents { get; } = new GuildDirectMessageEvents();
    public MessageAuditEvents MessageAuditEvents { get; } = new MessageAuditEvents();
    public ForumEvents ForumEvents { get; } = new ForumEvents();
    public AudioEvents AudioEvents { get; } = new AudioEvents();

    [Obsolete("这个事件没有做好，不会使用")]
    public QqGuildWebSocketEvent<InteractionEventArgs>? OnCreateInteractionMessage => null;
    
    public QqGuildWebSocketEvent<MessageCreateEventArgs>? OnCreateAtMessage { get; set; }
    
    public QqGuildWebSocketEvent<MessageDeleteEventArgs>? OnDeletePublicMessage { get; set; }
}

