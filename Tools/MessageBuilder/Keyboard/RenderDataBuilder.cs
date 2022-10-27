using QqGuildRobotSdk.Messages.Keyboard;

namespace QqGuildRobotSdk.Tools.MessageBuilder.Keyboard;

public class RenderDataBuilder
{
    private RenderData _renderData = new RenderData();

    public RenderDataBuilder Label(string label)
    {
        _renderData.Label = label;
        return this;
    }
    
    public RenderDataBuilder VisitedLabel(string visitedLabel)
    {
        _renderData.VisitedLabel = visitedLabel;
        return this;
    }
    
    public RenderDataBuilder RenderStyle(RenderStyle renderStyle)
    {
        _renderData.RenderStyle = renderStyle;
        return this;
    }

    public RenderData Build() => _renderData;
}