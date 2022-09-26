using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models;

public class Member
{
    [JsonProperty("user")]
    public User User { get; private set; } = new User();

    [JsonProperty("nick")]
    public string NickName { get; private set; } = "";

    [JsonProperty("roles")]
    public string[] Roles { get; private set; } = Array.Empty<string>();

    [JsonProperty("joined_at")]
    public string JoinedAt { get; private set; } = "";

    public static Member Empty { get; } = new Member();
}