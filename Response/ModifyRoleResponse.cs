using Newtonsoft.Json;
using QqGuildRobotSdk.Models;

namespace QqGuildRobotSdk.Response;

public class ModifyRoleResponse
{
    [JsonProperty("guild_id")]
    public string GuildId { get; private set; } = "";
    
    [JsonProperty("role_id")]
    public string RoleId { get; private set; } = "";

    [JsonProperty("role")]
    public Role Role { get; private set; } = new Role();
}