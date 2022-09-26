using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.PacketHandlers.MessageAudits;

namespace QqChannelRobotSdk.WebSocket.Events;

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

    [Obsolete("这个事件没有做好，不会使用")]
    public QqGuildWebSocketEvent<InteractionEventArgs>? OnCreateInteractionMessage => null;
    
    public QqGuildWebSocketEvent<MessageCreateEventArgs>? OnCreateAtMessage { get; set; }
    
    public QqGuildWebSocketEvent<MessageDeleteEventArgs>? OnDeletePublicMessage { get; set; }
}

