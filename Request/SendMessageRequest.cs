using Newtonsoft.Json;
using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.Messages.Ark;
using QqChannelRobotSdk.Messages.Embed;
using QqChannelRobotSdk.Messages.Markdown;

namespace QqChannelRobotSdk.Request;

public class SendMessageRequest
{
    [JsonProperty("content")]
    public string? Content { get; set; }

    [JsonProperty("embed")]
    public MessageEmbed? Embed { get; set; }
    
    [JsonProperty("ark")]
    public MessageArk? Ark { get; set; } 
    
    [JsonProperty("message_reference")]
    public MessageReference? Reference { get; set; }
    
    [JsonProperty("image")]
    public MessageReference? Image { get; set; }
    
    [JsonProperty("msg_id")]
    public string? MessageIdToReply { get; set; }
    
    [JsonProperty("event_id")]
    public string? EventIdToReply { get; set; }
    
    [JsonProperty("markdown")]
    public MessageMarkdown? Markdown { get; set; }
    
    
}