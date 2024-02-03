using QqGuildRobotSdk.Authenticate;
using QqGuildRobotSdk.WebSocket.Models;

namespace QqGuildRobotSdk.WebSocket;

public class QqGuildWebSocketClientInfo
{
    public QqGuildWebSocketClientInfo(BotIdentifier identifier)
    {
        Identifier = identifier;
        CreateParameters = new QqGuildWebSocketClientCreateParameters(identifier);
    }
    public int Version { get; internal set; }
    public string SessionId { get; internal set; } = "";
    public int CurrentShard { get; internal set; } 
    public WebSocketUser CurrentUser { get; internal set; } = WebSocketUser.Empty;
    public BotIdentifier Identifier { get; internal set; } 
    
    public QqGuildWebSocketClientCreateParameters CreateParameters { get; set; } 
}