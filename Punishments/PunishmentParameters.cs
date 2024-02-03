using QqGuildRobotSdk.WebSocket;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;

namespace QqGuildRobotSdk.Punishments;

public class PunishmentParameters
{
    public PunishmentParameters(QqGuildWebSocketClient? client, IPunishment? punishment, MessageCreateEventArgs eventArgs, int violationCount = -1)
    {
        Client = client;
        Punishment = punishment;
        EventArgs = eventArgs;
        ViolationCount = violationCount;
    }
    public QqGuildWebSocketClient? Client { get; set; }
    public IPunishment? Punishment { get; set; }
    public MessageCreateEventArgs EventArgs { get; set; }
    public int ViolationCount { get; set; }
}