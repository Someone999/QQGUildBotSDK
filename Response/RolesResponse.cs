using Newtonsoft.Json;
using QqChannelRobotSdk.Models;

namespace QqChannelRobotSdk.Response;

public class RolesResponse
{
    [JsonProperty("guild_id")]
    public string GuildId { get; private set; } = "";

    [JsonProperty("roles")]
    public Role[] Roles { get; private set; } = Array.Empty<Role>();
    
    [JsonProperty("role_num_limit")]
    public int RoleMemberCountLimit { get; private set; }
}