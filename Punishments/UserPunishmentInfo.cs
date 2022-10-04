using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public class UserPunishmentInfo
{
    public List<IPunishment> AppliedPunishment { get; } = new List<IPunishment>();
    public UserPunishmentInfo(User user)
    {
        User = user;
    }
    public User User { get; }
    public PunishmentExecutionResult ApplyPunishment(IPunishment punishment, MessageCreateEventArgs eventArgs, int violationCount)
    {
        AppliedPunishment.Add(punishment);
        return punishment.Punish(eventArgs, violationCount);
    }
}