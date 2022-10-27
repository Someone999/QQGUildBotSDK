using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages;

public class MessageReference
{
    [JsonProperty("message_id")]
    public string MessageId { get; set; } = "";
    
    [JsonProperty("ignore_get_message_error")]
    public bool IgnoreGetMessageError { get; set; }
}