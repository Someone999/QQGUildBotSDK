using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Members;

public class MemberWithGuildId : Member
{
    [JsonProperty("guild_id")]
    public string GuildId { get; private set; } = "";
}