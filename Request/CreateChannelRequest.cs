using Newtonsoft.Json;
using QqChannelRobotSdk.Models;

namespace QqChannelRobotSdk.Request;

public class CreateChannelRequest
{
    [JsonProperty("name")]
    public string Name { get; set; } = "";

    [JsonProperty("type")]
    public ChannelType ChannelType { get; set;} = ChannelType.Unknown;

    [JsonProperty("sub_type")]
    public ChannelSubType ChannelSubType { get; set;} = ChannelSubType.Unknown;
    
    [JsonProperty("position")]
    public int Position { get; set; }

    [JsonProperty("parent_id")]
    public string ParentId { get; set; } = "";
    
    [JsonProperty("private_type")]
    public PrivateType PrivateType { get; set; } = PrivateType.Unknown;

    [JsonProperty("private_user_ids")]
    public List<string> PrivateUserIds { get; set; } = new List<string>(); 

    [JsonProperty("speak_permission")]
    public SpeakPermission SpeakPermission { get; set;} = SpeakPermission.Unknown;
    
    [JsonProperty("application_id")]
    public ApplicationType ApplicationType { get; set;} = ApplicationType.Unknown;
}