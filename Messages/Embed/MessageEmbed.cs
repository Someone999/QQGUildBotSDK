using Newtonsoft.Json;

namespace QqChannelRobotSdk.Messages.Embed;

public class MessageEmbed
{
    [JsonProperty("title")]
    public string Title { get; set; } = "";
    
    [JsonProperty("prompt")]
    public string Prompt { get; set; } = "";

    [JsonProperty("thumbnail")]
    public MessageEmbedThumbnail? Thumbnail { get; set; }
    
    [JsonProperty("fields")]
    public MessageEmbedField? Fields { get; set; }

}