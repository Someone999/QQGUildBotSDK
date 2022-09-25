using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Keyboard;

public class MessageKeyboardPermission
{
    [JsonProperty("type")]
    public MessageKeyboardPermissionType PermissionType { get; set; }

    [JsonProperty("specify_role_ids")]
    public List<string> SpecifyRoleIds { get; set; } = new List<string>();
    
    [JsonProperty("specify_user_ids")]
    public List<string> SpecifyUserIds { get; set; } = new List<string>();
}