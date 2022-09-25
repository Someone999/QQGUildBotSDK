using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.WebSocket.Events;

public class MessageAuditEvents
{
    internal MessageAuditEvents()
    {
    }
    public QqGuildWebSocketEvent<MessageAuditEventArgs>? OnMessageAuditPassed { get; set; }
    public QqGuildWebSocketEvent<MessageAuditEventArgs>? OnMessageAuditRejected  { get; set; }
    
}