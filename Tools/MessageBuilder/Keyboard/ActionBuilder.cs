using QqGuildRobotSdk.Messages.Keyboard;
using Action = QqGuildRobotSdk.Messages.Keyboard.Action;

namespace QqGuildRobotSdk.Tools.MessageBuilder.Keyboard;

public class ActionBuilder
{
    private Action _action = new Action();
    public ActionBuilder ActionType(ActionType actionType)
    {
        _action.ActionType = actionType;
        return this;
    }

    public ActionBuilder ClickLimit(int clickLimit)
    {
        _action.ClickLimit = clickLimit;
        return this;
    }

    public ActionBuilder AtBotShowChannelList(bool val)
    {
        _action.AtBotShowChannelList = val;
        return this;
    }

    public ActionBuilder Data(string data)
    {
        _action.Data = data;
        return this;
    }

    public ActionBuilder Permission(MessageKeyboardPermission permission)
    {
        _action.Permission = permission;
        return this;
    }

    public Action Build() => _action;
}