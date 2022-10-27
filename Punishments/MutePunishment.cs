using QqGuildRobotSdk.Request;
using QqGuildRobotSdk.Tools;

namespace QqGuildRobotSdk.Punishments;

public class MutePunishment : IPunishment
{
    public int MaxViolationCount { get; set; } = 20;
    public int MinViolationCount { get; set; } = 0;
    public int Priority { get; set; } = 1;
    public PunishmentExecutionFlags Punish(PunishmentParameters parameters)
    {
        if (!MathUtils.InRange(parameters.ViolationCount, MinViolationCount, MaxViolationCount))
        {
            return PunishmentExecutionFlags.Unhandled;
        }
        int sec = parameters.ViolationCount * Math.Max(parameters.ViolationCount - 5, 0);
        MuteRequest request = new MuteRequest
        {
            MuteSeconds = sec.ToString()
        };
        string guildId = parameters.EventArgs.Message.GuildId;
        string userId = parameters.EventArgs.Message.Author.Id;
        Console.WriteLine($"尝试禁言用户{parameters.EventArgs.Message.Author.UserName}");
        var client = parameters.Client;
        if (client == null)
        {
            return PunishmentExecutionFlags.Unhandled;
        }
        
        var rslt =
            client.Sdk.MuteMemberAsync(guildId, userId, request).Result;
        
        return rslt != null
            ? PunishmentExecutionFlags.Handled
            : PunishmentExecutionFlags.Failed;
    }
}