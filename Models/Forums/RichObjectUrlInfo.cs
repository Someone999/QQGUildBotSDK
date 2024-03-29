﻿using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Forums;

public class RichObjectUrlInfo
{
    [JsonProperty("url")]
    public string Url { get; private set; } = "";

    [JsonProperty("display_text")]
    public string DisplayText { get; private set; } = "";
}