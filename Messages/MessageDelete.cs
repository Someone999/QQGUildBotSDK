using Newtonsoft.Json;
using QqChannelRobotSdk.Models;

namespace QqChannelRobotSdk.Messages;

public class MessageDelete
{
    [JsonProperty("message")]
    public Message Message { get; private set; } = Message.Empty;
    
    [JsonProperty("op_user")]
    public User OperatorUser { get; private set; } = User.Empty;
}