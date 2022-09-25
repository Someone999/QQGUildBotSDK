using Newtonsoft.Json;
using QqChannelRobotSdk.Models;

namespace QqChannelRobotSdk.Response;

public class CreateRoleResponse
{
    [JsonProperty("role_id")]
    public string RoleId { get; private set; } = "";

    [JsonProperty("role")]
    public Role Role { get; private set; } = new Role();
}