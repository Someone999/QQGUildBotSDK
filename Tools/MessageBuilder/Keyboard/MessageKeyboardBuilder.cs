using QqGuildRobotSdk.Messages.Keyboard;

namespace QqGuildRobotSdk.Tools.MessageBuilder.Keyboard;

public class MessageKeyboardBuilder
{
    private Dictionary<string, InlineKeyboardRow> _rows = new Dictionary<string, InlineKeyboardRow>();
    private Dictionary<(string, string), Button> _buttons = new Dictionary<(string, string), Button>();

    public void AddRow(string name, InlineKeyboardRow keyboardRow)
    {
        _rows.Add(name, keyboardRow);
    }

    public void AddButtonToRow(string rowName, string buttonName, Button button)
    {
        _rows[rowName].Buttons.Add(button);
        _buttons.Add((rowName, buttonName), button);
    }

    public Messages.Keyboard.MessageKeyboard Build()
    {
        Messages.Keyboard.MessageKeyboard messageKeyboard = new Messages.Keyboard.MessageKeyboard();
        messageKeyboard.Content = new InlineKeyboard();
        messageKeyboard.Content.Rows.AddRange(_rows.Values);
        return messageKeyboard;
    }

    public InlineKeyboardRow GetRow(string rowName) => _rows[rowName];

    public Button GetRowButton(string rowName, string buttonName) => _buttons[(rowName, buttonName)];
}