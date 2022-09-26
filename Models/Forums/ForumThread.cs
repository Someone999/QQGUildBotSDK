using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums
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
