using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class ForumAtUserInfo
{
    [JsonProperty("id")]
    public string Id { get; private set; } = "";

    [JsonProperty("nick")]
    public string NickName { get; private set; } = "";

    public static ForumAtUserInfo Empty { get; } = new ForumAtUserInfo();
}