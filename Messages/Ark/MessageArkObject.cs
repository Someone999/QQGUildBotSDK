using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Ark;

public class MessageArkObject
{
    [JsonProperty("obj_kv")]
    public MessageArkObjectKeyValuePair[] KeyValuePairs { get; set; } = Array.Empty<MessageArkObjectKeyValuePair>();
}