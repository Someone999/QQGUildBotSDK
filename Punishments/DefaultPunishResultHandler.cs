using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public class DefaultPunishResultHandler : IPunishResultHandler
{
    public void Handle(IPunishment? punishment, PunishmentExecutionResult result, MessageCreateEventArgs eventArgs)
    {
        User user = eventArgs.Message.Author;
        switch (result)
        {
            case PunishmentExecutionResult.ResetCounter:
                UserPunishmentManager.GetInstance().UserPunishments[user].AppliedPunishment.Clear();
                break;
            case PunishmentExecutionResult.RemoveId:
                UserPunishmentManager.GetInstance().UserPunishments.Remove(user);
                break;
            case PunishmentExecutionResult.Unhandled:
            case PunishmentExecutionResult.Failed:
            case PunishmentExecutionResult.NoHandler:
            case PunishmentExecutionResult.Handled:
            default:
                break;
        }
    }
}