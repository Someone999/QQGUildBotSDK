﻿using Newtonsoft.Json;
using QqChannelRobotSdk.Models;

namespace QqChannelRobotSdk.Response;

public class RoleMembersResponse
{
    [JsonProperty("data")]
    public Member[] Members { get; private set; } = Array.Empty<Member>();
    
    [JsonProperty("next")]
    public string Next { get; set; } = "";
}