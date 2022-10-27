using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Keyboard;

public class InlineKeyboard
{
    [JsonProperty("rows")]
    public List<InlineKeyboardRow> Rows { get; } = new(5);
}