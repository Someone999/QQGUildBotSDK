using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Keyboard;

public class InlineKeyboard
{
    [JsonProperty("rows")]
    public List<InlineKeyboardRow> Rows { get; } = new(5);
}