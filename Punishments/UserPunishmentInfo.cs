using QqGuildRobotSdk.Models;

namespace QqGuildRobotSdk.Punishments;

public class UserPunishmentInfo
{
    public List<IPunishment> AppliedPunishment { get; } = new List<IPunishment>();
    public UserPunishmentInfo(User user)
    {
        User = user;
    }
    public User User { get; }
    public async Task<PunishmentExecutionFlags> ApplyPunishmentAsync(PunishmentParameters parameters)
    {
        if (parameters.Punishment == null)
        {
            return PunishmentExecutionFlags.NoHandler;
        }
        AppliedPunishment.Add(parameters.Punishment);
        return await parameters.Punishment.PunishAsync(parameters);
    }
}