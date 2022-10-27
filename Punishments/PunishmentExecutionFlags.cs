namespace QqGuildRobotSdk.Punishments;

[Flags]
public enum PunishmentExecutionFlags
{
    Unhandled = 1,
    Failed = Unhandled | 2,
    NoHandler = Unhandled | 4,
    Handled = 8,
    ResetCounter = 16,
    RemoveId = 32
}