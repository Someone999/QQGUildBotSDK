using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models.Messages
{
    public class MessageAudited
    {
        [JsonProperty("audit_id")]
        public string AuditId { get; private set; } = "";

        [JsonProperty("message_id")]
        public string MessageId { get; private set; } = "";

        [JsonProperty("guild_id")]
        public string GuildId { get; private set; } = "";

        [JsonProperty("channel_id")]
        public string ChannelId { get; private set; } = "";

        [JsonProperty("audit_time")]
        public string AuditTime { get; private set; } = "";

        [JsonProperty("create_time")]
        public string CreateTime { get; private set; } = "";

        [JsonProperty("seq_in_channel")]
        public string SequenceInChannel { get; private set; } = "";
    }
}
