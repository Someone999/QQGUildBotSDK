using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class ForumAtRoleInfo
{
    [JsonProperty("role_id")]
    public string RoleId { get; private set; } = "";

    [JsonProperty("name")]
    public string Name { get; private set; } = "";

    [JsonProperty("color")]
    public uint Color { get; private set; }

    public static ForumAtRoleInfo Empty { get; } = new ForumAtRoleInfo();
}