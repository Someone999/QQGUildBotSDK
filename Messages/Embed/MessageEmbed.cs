using Newtonsoft.Json;

namespace QqGuildRobotSdk.Messages.Embed;

public class MessageEmbed
{
    [JsonProperty("title")]
    public string Title { get; set; } = "";
    
    [JsonProperty("prompt")]
    public string Prompt { get; set; } = "";

    [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
    public MessageEmbedThumbnail? Thumbnail { get; set; }
    
    [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
    public List<MessageEmbedField>? Fields { get; set; }

}