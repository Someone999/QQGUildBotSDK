using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Forums
{
    public class EmojiInfo
    {
        [JsonProperty("id")]
        public string Id { get; private set; } = "";

        [JsonProperty("type")]
        public string EmojiType { get; private set; } = "";

        [JsonProperty("name")]
        public string Name { get; private set; } = "";


        [JsonProperty("url")]
        public string Url { get; private set; } = "";

    }
}
