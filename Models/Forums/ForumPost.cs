using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums;

public class ForumPost
{
    [JsonProperty("guild_id")]
    public string GuildId { get; private set; } = "";

    [JsonProperty("channel_id")]
    public string ChannelId { get; private set; } = "";

    [JsonProperty("author_id")]
    public string AuthorId { get; private set; } = "";

    //[JsonProperty("guild_id")]
    [JsonProperty("post_info")]
    public ForumPostInfo ForumPostInfo { get; private set; } = ForumPostInfo.Empty;


}