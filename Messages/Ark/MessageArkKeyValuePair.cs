using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Ark;

public class MessageArkKeyValuePair
{
    [JsonProperty("key")]
    public string Key { get; set; } = "";
    
    [JsonProperty("value")]
    public string Value { get; set; } = "";

    [JsonProperty("obj")]
    public MessageArkObject MessageArkObject { get; set; } = new MessageArkObject();
}