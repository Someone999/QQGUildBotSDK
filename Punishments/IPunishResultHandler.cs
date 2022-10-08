using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public interface IPunishResultHandler
{
    void Handle(IPunishment? punishment, PunishmentExecutionResult result, MessageCreateEventArgs eventArgs);
}