using QqGuildRobotSdk.Models;
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

public class UserPunishmentInfo
{
    public List<IPunishment> AppliedPunishment { get; } = new List<IPunishment>();
    public UserPunishmentInfo(User user)
    {
        User = user;
    }
    public User User { get; }
    public PunishmentExecutionFlags ApplyPunishment(PunishmentParameters parameters)
    {
        if (parameters.Punishment == null)
        {
            return PunishmentExecutionFlags.NoHandler;
        }
        AppliedPunishment.Add(parameters.Punishment);
        return parameters.Punishment.Punish(parameters);
    }
}