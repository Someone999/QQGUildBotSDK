using Newtonsoft.Json;
using QqChannelRobotSdk.Tools;

namespace QqChannelRobotSdk.Models;

public class Guild
{
    [JsonProperty("id")]
    public string Id { get; set; } = "";
    
    [JsonProperty("name")]
    public string Name { get; set; } = "";
    
    [JsonProperty("icon")]
    public string Icon { get; set; } = "";
    
    [JsonProperty("owner_id")]
    public string OwnerId { get; set; } = "";
    
    [JsonProperty("owner")]
    public bool IsOwner { get; set; }
    
    [JsonProperty("member_count")]
    public int MemberCount { get; set; }
    
    [JsonProperty("max_members")]
    public int MaxMemberCount { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; } = "";
    
    [JsonProperty("joined_at")]
    public string JoinedAt { get; set; } = "";
    
}