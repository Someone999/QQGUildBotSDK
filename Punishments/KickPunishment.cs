using QqChannelRobotSdk.WebSocket;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public class KickPunishment : IPunishment
{

    public KickPunishment(QqGuildWebSocketClient client)
    {
        Client = client;
    }
    public QqGuildWebSocketClient Client { get; set; }
    public PunishmentExecutionResult Punish(MessageCreateEventArgs eventArgs, int violationCount)
    {
        if (violationCount < 20)
        {
            return PunishmentExecutionResult.Unhandled;
        }

        string guildId = eventArgs.Message.GuildId;
        string userId = eventArgs.Message.Author.Id;
        var rslt = Client.Sdk.RemoveMemberAsync(guildId, userId).Result;
        return rslt.Succsee
            ? PunishmentExecutionResult.ResetCounter
            : PunishmentExecutionResult.Failed;
    }
}