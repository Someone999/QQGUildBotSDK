using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Markdown;

public class MessageMarkdown
{
    [JsonProperty("template_id", NullValueHandling = NullValueHandling.Ignore)]
    public string? TemplateId { get; set; }

    [JsonProperty("custom_template_id", NullValueHandling = NullValueHandling.Ignore)]
    public string? CustomTemplateId { get; set; } = "";

    [JsonProperty("params", NullValueHandling = NullValueHandling.Ignore)]
    public MessageMarkdownParams? Parameters { get; set; }

    [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
    public string? Content { get; set; }
}