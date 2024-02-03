using QqGuildRobotSdk.WebSocket.Events.EventArgs;

namespace QqGuildRobotSdk.Punishments;

public interface IPunishResultHandler
{
    Task Handle(IPunishment? punishment, PunishmentExecutionFlags flags, MessageCreateEventArgs eventArgs);
}