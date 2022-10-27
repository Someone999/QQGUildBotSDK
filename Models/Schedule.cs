using Newtonsoft.Json;
using QqGuildRobotSdk.Messages.MessageReaction;
using QqGuildRobotSdk.Models.Members;

namespace QqGuildRobotSdk.Models;

public class Schedule
{
    [JsonProperty("id")]
    public string Id { get; private set; } = "";

    [JsonProperty("name")]
    public string Name { get; set; } = "";
    
    [JsonProperty("description")]
    public string Description { get; set; } = "";
    
    [JsonProperty("start_timestamp")]
    public string StartTimestamp { get; set; } = "";
    
    [JsonProperty("end_timestamp")]
    public string EndTimestamp { get; set; } = "";
    
    [JsonProperty("creator")]
    public Member Creator { get; set; } = Member.Empty;
    
    [JsonProperty("jump_channel_id")]
    public string JumpChannelId { get; set; } = "";
    
    [JsonProperty("remind_type")]
    public RemindType RemindType { get; set; } = RemindType.None;

    public static Schedule Empty { get; } = new Schedule();
}