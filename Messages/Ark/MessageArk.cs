using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Ark;

public class MessageArk
{
    [JsonProperty("template_id")]
    public int TemplateId { get; set; }

    [JsonProperty("kv")]
    public MessageArkKeyValuePair[] KeyValuePairs { get; set; } = Array.Empty<MessageArkKeyValuePair>();
}