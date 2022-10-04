using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Channels;

public class Channel
{
    [JsonProperty("id")]
    public string Id { get; private set; } = "";

    [JsonProperty("guild_id")]
    public string GuildId { get; private set; } = "";

    [JsonProperty("name")]
    public string Name { get; private set; } = "";

    [JsonProperty("type")]
    public ChannelType ChannelType { get; private set;} = ChannelType.Unknown;

    [JsonProperty("sub_type")]
    public ChannelSubType ChannelSubType { get; private set;} = ChannelSubType.Unknown;
    
    [JsonProperty("position")]
    public int Position { get; private set; }

    [JsonProperty("parent_id")]
    public string ParentId { get; private set; } = "";
    
    [JsonProperty("owner_id")]
    public string OwnerId { get; private set; } = "";

    [JsonProperty("private_type")]
    public PrivateType PrivateType { get; private set; } = PrivateType.Unknown;

    [JsonProperty("speak_permission")]
    public SpeakPermission SpeakPermission { get; private set;} = SpeakPermission.Unknown;
    
    [JsonProperty("application_id")]
    public ApplicationType ApplicationType { get; private set;} = ApplicationType.Unknown;

    [JsonProperty("permission")]
    public string Permission { get; private set;} = "";

}