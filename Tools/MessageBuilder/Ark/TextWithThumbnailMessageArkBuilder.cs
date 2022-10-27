using QqGuildRobotSdk.Messages.Ark;

namespace QqGuildRobotSdk.Tools.MessageBuilder.Ark;

public class TextWithThumbnailMessageArkBuilder
{
    public string Description { get; set; } = "";
    public string Prompt { get; set; } = "";
    public string Title { get; set; } = "";
    public string MetaDescription { get; set; } = "";
    public string Image { get; set; } = "";
    public string Link { get; set; } = "";
    public string SubTitle { get; set; } = "";

    public MessageArk Build()
    {
        MessageArk message = new MessageArk
        {
            TemplateId = MessageArkTemplates.TextWithThumbnail
        };
        
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#DESC#", Description));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#PROMPT#", Prompt));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#TITLE#", Title));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#METADESC#", MetaDescription));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#IMG#", Image));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#LINK#", Link));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#SUBTITLE#", SubTitle));
        return message;
    }
}