using QqGuildRobotSdk.Authenticate;
using QqGuildRobotSdk.Tools;
using QqGuildRobotSdk.WebSocket.Models;

namespace QqGuildRobotSdk.WebSocket;

public class QqGuildWebSocketClientCreateParameters
{
    public QqGuildWebSocketClientCreateParameters(BotIdentifier identifier)
    {
        Identifier = identifier;
    }
    public BotIdentifier Identifier { get; set; }
    public bool UseSandboxEnvironment { get; set; }
    public int? MaxShardCount { get; set; }
    
    /// <summary>
    /// WssUrl can be get in <seealso cref="QqGuildRobotSdk.WebSocket.Utils.QqGuildWebSocketConnectionUtils"/>
    /// </summary>
    public string? WssUrl { get; set; }
    public PrimaryEventType RegisteredEvents { get; set; }
    public bool AutoStart { get; set; }
}