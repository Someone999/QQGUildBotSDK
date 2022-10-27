using QqGuildRobotSdk.Tools;

namespace QqGuildRobotSdk.Punishments;

public class KickPunishment : IPunishment
{
    public int MaxViolationCount { get; set; } = int.MaxValue;
    public int MinViolationCount { get; set; } = 20;
    public int Priority { get; set; } = 1;
    public PunishmentExecutionFlags Punish(PunishmentParameters parameters)
    {
        
        if (!MathUtils.InRange(parameters.ViolationCount, MinViolationCount, MaxViolationCount))
        {
            return PunishmentExecutionFlags.Unhandled;
        }
        
        
        string guildId = parameters.EventArgs.Message.GuildId;
        string userId = parameters.EventArgs.Message.Author.Id;
        var client = parameters.Client;
        if (client == null)
        {
            return PunishmentExecutionFlags.Unhandled;
        }
        
        Console.WriteLine($"尝试踢出用户{parameters.EventArgs.Message.Author.UserName}");
        var rslt = client.Sdk.RemoveMemberAsync(guildId, userId).Result;
        return rslt.Success
            ? PunishmentExecutionFlags.ResetCounter
            : PunishmentExecutionFlags.Failed;
    }
}