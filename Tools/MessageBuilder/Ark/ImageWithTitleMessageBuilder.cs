using QqGuildRobotSdk.Messages.Ark;

namespace QqGuildRobotSdk.Tools.MessageBuilder.Ark;

public class ImageWithTitleMessageBuilder
{
    public string Prompt { get; set; } = "";
    public string MetaTitle { get; set; } = "";
    public string MetaCover { get; set; } = "";
    public string MetaUrl { get; set; } = "";
    public string MetaSubTitle { get; set; } = "";

    public MessageArk Build()
    {
        MessageArk message = new MessageArk
        {
            TemplateId = MessageArkTemplates.ImageWithTitleMessage
        };
        
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#PROMPT#", Prompt));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#METATITLE#", MetaTitle));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#METASUBTITLE#", MetaSubTitle));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#METACOVER#", MetaCover));
        message.KeyValuePairs.Add(new MessageArkKeyValuePair("#METAURL#", MetaUrl));
        return message;
    }
}