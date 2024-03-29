﻿using Newtonsoft.Json;

namespace QqGuildRobotSdk.Models.Channels;

public class ChannelPermissions
{
    [JsonProperty("channel_id")]
    public string ChannelId { get; private set; } = "";

    [JsonProperty("user_id")]
    public string? UserId { get; private set; } = "";

    [JsonProperty("role_id")]
    public string? RoleId { get; private set; } = "";

    [JsonProperty("permissions")]
    private string InnerPermissions { get; set; } = "0";

    public ChannelPermission ChannelPermission => (ChannelPermission)int.Parse(InnerPermissions);
}