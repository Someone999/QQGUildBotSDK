using Newtonsoft.Json;

namespace QqChannelRobotSdk.Request;

public class ModifyRoleRequest
{
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("color")]
    public uint? Color { get; set; }

    [JsonProperty("hoist")]
    private int? InnerHoist => Hoist
        ? 1
        : 0;
    
    [JsonIgnore]
    public bool Hoist { get; set; }
}