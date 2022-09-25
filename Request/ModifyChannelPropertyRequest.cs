using Newtonsoft.Json;
using QqChannelRobotSdk.Models;

namespace QqChannelRobotSdk.Request;

public class ModifyChannelPropertyRequest
{
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("position")]
    public int? Position { get; set; }
    
    [JsonProperty("parent_id")]
    public string? ParentId { get; set; }
    
    [JsonProperty("private_type")]
    public PrivateType PrivateType { get; set; }
    
    [JsonProperty("speak_permission")]
    public SpeakPermission SpeakPermission { get; set; }
    
}