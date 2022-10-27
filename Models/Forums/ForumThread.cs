using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums
{
    public class ForumThread
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; private set; } = "";

        [JsonProperty("channel_id")]
        public string ChannelId { get; private set; } = "";


        [JsonProperty("author_id")]
        public string AuthorId { get; private set; } = "";

        //[JsonProperty("guild_id")]
        [JsonProperty("thread_info")]
        public ForumThreadInfo ForumThreadInfo { get; private set; } = ForumThreadInfo.Empty;


    }
}
