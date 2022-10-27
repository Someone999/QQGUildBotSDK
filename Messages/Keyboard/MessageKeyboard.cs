using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Keyboard;

public class MessageKeyboard
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? TemplateId { get; set; } = "";

    [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
    public InlineKeyboard? Content { get; set; }
}