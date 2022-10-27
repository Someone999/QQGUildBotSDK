using Newtonsoft.Json;
using QqGuildRobotSdk.Messages;
using QqGuildRobotSdk.Messages.Ark;
using QqGuildRobotSdk.Messages.Embed;
using QqGuildRobotSdk.Messages.Keyboard;
using QqGuildRobotSdk.Messages.Markdown;

namespace QqGuildRobotSdk.Request;

public class SendMessageRequest
{
    [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
    public string? Content { get; set; }

    [JsonProperty("embed", NullValueHandling = NullValueHandling.Ignore)]
    public MessageEmbed? Embed { get; set; }
    
    [JsonProperty("ark", NullValueHandling = NullValueHandling.Ignore)]
    public MessageArk? Ark { get; set; } 
    
    [JsonProperty("message_reference", NullValueHandling = NullValueHandling.Ignore)]
    public MessageReference? Reference { get; set; }
    
    [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
    public MessageReference? Image { get; set; }
    
    [JsonProperty("msg_id", NullValueHandling = NullValueHandling.Ignore)]
    public string? MessageIdToReply { get; set; }
    
    [JsonProperty("event_id", NullValueHandling = NullValueHandling.Ignore)]
    public string? EventIdToReply { get; set; }
    
    [JsonProperty("markdown", NullValueHandling = NullValueHandling.Ignore)]
    public MessageMarkdown? Markdown { get; set; }
    
    [JsonProperty("keyboard", NullValueHandling = NullValueHandling.Ignore)]
    public MessageKeyboard? Keyboard { get; set; }
}