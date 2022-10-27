using Newtonsoft.Json;

namespace QqGuildRobotSdk.Request;

public class CreateRoleRequest
{
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("color")]
    public uint Color { get; set; }

    [JsonProperty("hoist")]
    private int InnerHoist => Hoist
        ? 1
        : 0;
    
    [JsonIgnore]
    public bool Hoist { get; set; }
}