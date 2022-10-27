using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Messages;

public class MessageSetting
{
    [JsonProperty("disable_create_dm")]
    public bool DisableDirectMessage { get; private set; }
    
    [JsonProperty("disable_push_msg")]
    public bool DisablePushMessage { get; private set; }
    
    [JsonProperty("channel_ids")]
    public List<string>? ChannelIds { get; private set; }
    
    [JsonProperty("channel_push_max_num")]
    public int ChannelMaxMessagePushCount { get; set; }
    
    


}