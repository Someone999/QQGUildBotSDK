using QqChannelRobotSdk.Authenticate;
using QqChannelRobotSdk.WebSocket.Models;

namespace QqChannelRobotSdk.WebSocket;

public class QqGuildWebSocketClientCreateParameters
{
    public QqGuildWebSocketClientCreateParameters(BotIdentifier identifier)
    {
        Identifier = identifier;
    }
    public BotIdentifier Identifier { get; set; }
    public int? MaxShardCount { get; set; } = null;
    

    public PrimaryEventType RegisteredEvents { get; set; }
}