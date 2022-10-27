using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Ark;

public class MessageArkObjectKeyValuePair
{
    public MessageArkObjectKeyValuePair(string key, string value)
    {
        Key = key;
        Value = value;
    }

    [JsonProperty("key")]
    public string Key { get; set; }
    
    [JsonProperty("value")]
    public string Value { get; set; }
}