using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Ark;

public class MessageArkKeyValuePair
{
    public MessageArkKeyValuePair(string key, string? value = null, List<MessageArkObject>? arkObjects = null)
    {
        Key = key;
        Value = value;
        MessageArkObjects = arkObjects;
    }
    

    [JsonProperty("key")]
    public string Key { get; set; }
    
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public string? Value { get; set; }

    [JsonProperty("obj", NullValueHandling = NullValueHandling.Ignore)]
    public List<MessageArkObject>? MessageArkObjects { get; set; }
}