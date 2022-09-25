using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Keyboard;

public class MessageKeyboard
{
    [JsonProperty("id")]
    public string TemplateId { get; set; } = "";
    
    
}