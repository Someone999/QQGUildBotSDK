﻿using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class ForumReplyInfo
{
    [JsonProperty("thread_id")]
    public string ThreadId { get; private set; } = "";

    [JsonProperty("post_id")]
    public string PostId { get; private set; } = "";

    [JsonProperty("reply_id")]
    public string ReplyId { get; private set; } = "";

    [JsonProperty("content")]

    public RichText Content { get; private set; } = new RichText();

    [JsonProperty("date_time")]

    public string DateTime { get; private set; } = "";

    public static ForumReplyInfo Empty { get; } = new ForumReplyInfo();
}