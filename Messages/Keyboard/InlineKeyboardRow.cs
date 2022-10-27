using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Keyboard;

public class InlineKeyboardRow
{
    [JsonProperty("button")]
    public List<Button> Buttons { get; } = new(5);
}