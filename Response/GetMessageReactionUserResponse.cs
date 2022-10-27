using Newtonsoft.Json;

namespace QqGuildRobotSdk.Response;

public class GetMessageReactionUserResponse
{
    [JsonProperty("id")]
    public string Id { get; private set; } = "";

    [JsonProperty("username")]
    public string UserName { get; private set; } = "";
    
    [JsonProperty("is_end")]
    public bool IsEnd { get; private set; }
}