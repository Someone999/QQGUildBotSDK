using QqChannelRobotSdk.Request;
using QqChannelRobotSdk.Sdk;
using QqChannelRobotSdk.Tools;
using QqChannelRobotSdk.WebSocket;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public class MutePunishment : IPunishment
{
    public int MaxViolationCount { get; set; } = 20;
    public int MinViolationCount { get; set; } = 0;
    public int Priority { get; set; } = 1;
    public PunishmentExecutionResult Punish(PunishmentParameters parameters)
    {
        if (!MathUtils.InRange(parameters.ViolationCount, MinViolationCount, MaxViolationCount))
        {
            return PunishmentExecutionResult.Unhandled;
        }
        int sec = parameters.ViolationCount * Math.Max(parameters.ViolationCount - 5, 0);
        MuteRequest request = new MuteRequest
        {
            MuteSeconds = sec.ToString()
        };
        string guildId = parameters.EventArgs.Message.GuildId;
        string userId = parameters.EventArgs.Message.Author.Id;
        Console.WriteLine($"尝试禁言用户{parameters.EventArgs.Message.Author.UserName}");
        var rslt =
            parameters.Client.Sdk.MuteMemberAsync(guildId, userId, request).Result;
        
        return rslt != null
            ? PunishmentExecutionResult.Handled
            : PunishmentExecutionResult.Failed;
    }
}