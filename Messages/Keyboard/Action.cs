using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Keyboard;

public class Action
{
    [JsonProperty("type")]
    public ActionType ActionType { get; set; }

    [JsonProperty("permission")]
    public MessageKeyboardPermission Permission { get; set; } = new MessageKeyboardPermission();
    
    [JsonProperty("click_limit")]
    public int ClickLimit { get; set; }

    [JsonProperty("data")]
    public string Data { get; set; } = "";
    
    [JsonProperty("at_bot_show_channel_list")]
    public bool AtBotShowChannelList { get; set; }
}