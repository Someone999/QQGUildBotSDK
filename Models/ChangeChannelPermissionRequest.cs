using System.Net.Sockets;
using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models;

public class ChangeChannelPermissionRequest
{
    [JsonProperty("add")]
    private ChannelPermission InnerToAdd { get; set; } = ChannelPermission.None;
    
    [JsonProperty("remove")]
    private ChannelPermission InnerToRemove{ get; set; } = ChannelPermission.None;
    public void AddPermission(ChannelPermission permission)
    {
        InnerToAdd |= permission;
    }

    public void RemovePermission(ChannelPermission permission)
    {
        InnerToRemove |= permission;
    }

    
}