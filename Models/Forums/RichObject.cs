using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class RichObject
{
    [JsonProperty("type")]
    public RichType RichType { get; private set; }

    [JsonProperty("text_info")]
    public RichObjectTextInfo TextInfo { get; private set; } = new RichObjectTextInfo();

    [JsonProperty("at_info")]
    public RichObjectAtInfo AtInfo { get; private set; } = new RichObjectAtInfo();

    [JsonProperty("url_info")]
    public RichObjectUrlInfo UrlInfo { get; private set; } = new RichObjectUrlInfo();

    [JsonProperty("emoji_info")]
    public RichObjectEmojiInfo EmojiInfo { get; private set; } = new RichObjectEmojiInfo();

    [JsonProperty("channel_info")]
    public RichObjectChannelInfo ChannelInfo { get; private set; } = new RichObjectChannelInfo();

}