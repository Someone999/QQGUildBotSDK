using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Markdown;

public class MessageMarkdownParams
{
    [JsonProperty("key")]
    public string Key { get; set; } = "";
    
    [JsonProperty("values")]
    public List<string> Values { get; } = new List<string>(1);
}