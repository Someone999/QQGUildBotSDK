using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class ForumAtGuildInfo
{
    [JsonProperty("guild_id")]
    public string GuildId { get; private set; } = "";

    [JsonProperty("guild_name")]
    public string GuildName { get; private set; } = "";
    public static ForumAtGuildInfo Empty { get; } = new ForumAtGuildInfo();
}