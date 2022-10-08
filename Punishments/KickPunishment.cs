using QqChannelRobotSdk.Tools;
using QqChannelRobotSdk.WebSocket;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public class KickPunishment : IPunishment
{
    public int MaxViolationCount { get; set; } = int.MaxValue;
    public int MinViolationCount { get; set; } = 20;
    public int Priority { get; set; } = 1;
    public PunishmentExecutionResult Punish(PunishmentParameters parameters)
    {
        
        if (!MathUtils.InRange(parameters.ViolationCount, MinViolationCount, MaxViolationCount))
        {
            return PunishmentExecutionResult.Unhandled;
        }
        
        
        string guildId = parameters.EventArgs.Message.GuildId;
        string userId = parameters.EventArgs.Message.Author.Id;
        
        Console.WriteLine($"尝试踢出用户{parameters.EventArgs.Message.Author.UserName}");
        var rslt = parameters.Client.Sdk.RemoveMemberAsync(guildId, userId).Result;
        return rslt.Succsee
            ? PunishmentExecutionResult.ResetCounter
            : PunishmentExecutionResult.Failed;
    }
}