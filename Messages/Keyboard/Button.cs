using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Keyboard;

public class Button
{
    [JsonProperty("id")]
    public string Id { get; set; } = "";

    [JsonProperty("render_data")]
    public RenderData RenderData { get; set; } = new RenderData();

    [JsonProperty("action")]
    public Action Action { get; set; } = new Action();
}