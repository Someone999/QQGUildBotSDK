using QqChannelRobotSdk.WebSocket;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public interface IPunishment
{
    QqGuildWebSocketClient Client { get; set; }
    PunishmentExecutionResult Punish(MessageCreateEventArgs eventArgs, int violationCount);
}