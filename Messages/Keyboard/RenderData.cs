using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Keyboard;

public class RenderData
{
    [JsonProperty("label")]
    public string Label { get; set; } = "";
    
    [JsonProperty("visited_label")]
    public string VisitedLabel { get; set; } = "";
    
    [JsonProperty("style")]
    public RenderStyle RenderStyle { get; set; }
}