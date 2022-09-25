using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Keyboard;

public class InlineKeyboardRow
{
    [JsonProperty("button")]
    public List<Button> Buttons { get; } = new(5);
}