namespace QqChannelRobotSdk.Punishments;

[Flags]
public enum PunishmentExecutionResult
{
    Unhandled = 1,
    Failed = Unhandled | 2,
    NoHandler = Unhandled | 4, 
    Handled = 8,
    ResetCounter = 16,
    RemoveId = 32
}