using QqGuildRobotSdk.WebSocket.Events.EventArgs;

namespace QqGuildRobotSdk.Punishments;

public interface IPunishResultHandler
{
    void Handle(IPunishment? punishment, PunishmentExecutionFlags flags, MessageCreateEventArgs eventArgs);
}