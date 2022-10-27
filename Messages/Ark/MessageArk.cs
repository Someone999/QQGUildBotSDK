using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Ark;

public class MessageArk
{
    [JsonProperty("template_id")]
    public int TemplateId { get; set; }

    [JsonProperty("kv")]
    public List<MessageArkKeyValuePair> KeyValuePairs { get; set; } = new();
}