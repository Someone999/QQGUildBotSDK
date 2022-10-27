using Newtonsoft.Json;
using QqGuildRobotSdk.Models;

namespace QqGuildRobotSdk.Messages;

public class MessageDelete
{
    [JsonProperty("message")]
    public Message Message { get; private set; } = Message.Empty;
    
    [JsonProperty("op_user")]
    public User OperatorUser { get; private set; } = User.Empty;
}