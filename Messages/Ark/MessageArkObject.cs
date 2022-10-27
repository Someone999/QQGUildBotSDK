using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Ark;

public class MessageArkObject
{
    [JsonProperty("obj_kv")]
    public List<MessageArkObjectKeyValuePair> KeyValuePairs { get; set; } = new List<MessageArkObjectKeyValuePair>();
}