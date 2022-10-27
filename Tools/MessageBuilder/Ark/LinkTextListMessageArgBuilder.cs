using QqGuildRobotSdk.Messages.Ark;

namespace QqGuildRobotSdk.Tools.MessageBuilder.Ark;

public class LinkTextListMessageArgBuilder
{
    public string Description { get; set; } = "";
    public string Prompt { get; set; } = "";
    private List<MessageArkObject> _contents = new List<MessageArkObject>();
    public void AddText(string text)
    {
        MessageArkObject arkObject = new MessageArkObject();
        arkObject.KeyValuePairs.Add(new MessageArkObjectKeyValuePair("desc", text));
        _contents.Add(arkObject);
    }

    public void AddLink(string text, string link)
    {
        MessageArkObject arkObject = new MessageArkObject();
        arkObject.KeyValuePairs.Add(new MessageArkObjectKeyValuePair("desc", text));
        arkObject.KeyValuePairs.Add(new MessageArkObjectKeyValuePair("link", link));
        _contents.Add(arkObject);
    }

    public MessageArk Build()
    {
        MessageArk message = new MessageArk
        {
            TemplateId = MessageArkTemplates.LinkAndTextList
        };
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#DESC#", Description));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#PROMPT#", Prompt));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#LIST#", arkObjects: _contents));
        return message;
    }
}