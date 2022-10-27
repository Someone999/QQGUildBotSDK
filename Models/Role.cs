using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models;

public class Role
{
    [JsonProperty("id")]
    public string Id { get; private set; } = "";

    [JsonProperty("name")]
    public string Name { get; private set; } = "";
    
    [JsonProperty("color")]
    public uint Color {get; private set; }
    
    [JsonProperty("hoist")]
    private int InnerHoist { get; set; }

    public bool Hoist => InnerHoist == 1;
    
    [JsonProperty("number")]
    public int MemberCount {get; private set; }
    
    [JsonProperty("member_limit")]
    public int MemberLimit {get; private set; }
}