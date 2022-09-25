using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Keyboard;

public class Button
{
    [JsonProperty("id")]
    public string Id { get; set; } = "";

    [JsonProperty("render_data")]
    public RenderData RenderData { get; set; } = new RenderData();
}