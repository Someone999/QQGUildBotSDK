using QqGuildRobotSdk.WebSocket.Events.EventArgs;

namespace QqGuildRobotSdk.WebSocket.Events;

public class MessageAuditEvents
{
    internal MessageAuditEvents()
    {
    }
    public QqGuildWebSocketEvent<MessageAuditEventArgs>? OnMessageAuditPassed { get; set; }
    public QqGuildWebSocketEvent<MessageAuditEventArgs>? OnMessageAuditRejected  { get; set; }
    
}