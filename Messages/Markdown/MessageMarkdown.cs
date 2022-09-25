using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Markdown;

public class MessageMarkdown
{
    [JsonProperty("template_id")]
    public string TemplateId { get; set; } = "";

    [JsonProperty("custom_template_id")]
    public string CustomTemplateId { get; set; } = "";

    [JsonProperty("params")]
    public MessageMarkdownParams Parameters { get; set; } = new MessageMarkdownParams();

    [JsonProperty("content")]
    public string Content { get; set; } = "";
}