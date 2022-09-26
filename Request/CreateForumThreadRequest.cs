using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QqChannelRobotSdk.Request
{
    public class CreateForumThreadRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; } = "";

        [JsonProperty("content")]
        public string Content { get; set; } = "";

        [JsonProperty("format")]
        public ThreadFormat ThreadFormat { get; set; }

    }

    public enum ThreadFormat
    {
        Text = 1,
        Html,
        Markdown,
        Json
    }
}
