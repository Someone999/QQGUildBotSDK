using QqGuildRobotSdk.Models;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;

namespace QqGuildRobotSdk.Punishments;

public class DefaultPunishResultHandler : IPunishResultHandler
{
    public Task Handle(IPunishment? punishment, PunishmentExecutionFlags flags, MessageCreateEventArgs eventArgs)
    {
        User user = eventArgs.Message.Author;
        switch (flags)
        {
            case PunishmentExecutionFlags.ResetCounter:
                UserPunishmentManager.GetInstance().UserPunishments[user].AppliedPunishment.Clear();
                break;
            case PunishmentExecutionFlags.RemoveId:
                UserPunishmentManager.GetInstance().UserPunishments.Remove(user);
                break;
            case PunishmentExecutionFlags.Unhandled:
            case PunishmentExecutionFlags.Failed:
            case PunishmentExecutionFlags.NoHandler:
            case PunishmentExecutionFlags.Handled:
            default:
                break;
        }
        
        return Task.CompletedTask;
    }
}