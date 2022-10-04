using QqChannelRobotSdk.Request;
using QqChannelRobotSdk.Sdk;
using QqChannelRobotSdk.WebSocket;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public class MutePunishment : IPunishment
{
    public MutePunishment(QqGuildBotSdk sdk, QqGuildWebSocketClient client)
    {
        Client = client;
    }
    public QqGuildWebSocketClient Client { get; set; }
    public PunishmentExecutionResult Punish(MessageCreateEventArgs eventArgs, int violationCount)
    {
        if (violationCount > 20)
        {
            return PunishmentExecutionResult.Unhandled;
        }
        int sec = violationCount * Math.Max(violationCount - 5, 0);
        MuteRequest request = new MuteRequest
        {
            MuteSeconds = sec.ToString()
        };
        string guildId = eventArgs.Message.GuildId;
        string userId = eventArgs.Message.Author.Id;
        var rslt =
            Client.Sdk.MuteMemberAsync(guildId, userId, request).Result;
        return rslt != null
            ? PunishmentExecutionResult.Handled
            : PunishmentExecutionResult.Failed;
    }
}