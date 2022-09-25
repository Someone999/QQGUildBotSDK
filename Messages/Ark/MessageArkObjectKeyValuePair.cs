using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Ark;

public class MessageArkObjectKeyValuePair
{
    [JsonProperty("key")]
    public string Key { get; set; } = "";
    
    [JsonProperty("value")]
    public string Value { get; set; } = "";
}