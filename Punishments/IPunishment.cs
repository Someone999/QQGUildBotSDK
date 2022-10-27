namespace QqGuildRobotSdk.Punishments;

public interface IPunishment
{
    int MaxViolationCount { get; set; }
    int MinViolationCount { get; set; }
    
    int Priority { get; set; }
    PunishmentExecutionFlags Punish(PunishmentParameters parameters);
}