using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Members;

public class MemberWithGuildId : Member
{
    [JsonProperty("guild_id")]
    public string GuildId { get; private set; } = "";
}