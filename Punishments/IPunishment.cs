using QqChannelRobotSdk.WebSocket;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public interface IPunishment
{
    int MaxViolationCount { get; set; }
    int MinViolationCount { get; set; }
    
    int Priority { get; set; }
    PunishmentExecutionResult Punish(PunishmentParameters parameters);
}