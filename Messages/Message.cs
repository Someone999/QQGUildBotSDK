using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using QqGuildRobotSdk.Messages.Ark;
using QqGuildRobotSdk.Messages.Embed;
using QqGuildRobotSdk.Models;
using QqGuildRobotSdk.Models.Members;

namespace QqGuildRobotSdk.Messages;

public class Message
{
    [JsonProperty("id")]
    public string Id { get; set; } = "";
    
    [JsonProperty("channel_id")]
    public string ChannelId { get; set; } = "";
    
    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = "";
    
    [JsonProperty("content")]
    public string Content { get; set; } = "";

    [JsonProperty("timestamp")]
    public string Timestamp { get; set; } = "";
    
    [JsonProperty("edited_timestamp")]
    public string EditedTimestamp { get; set; } = "";
    
    [JsonProperty("mention_everyone")]
    public bool MentionEveryone { get; set; }

    [JsonProperty("author")]
    public User Author { get; set; } = User.Empty;

    [JsonProperty("attachments")]
    public MessageAttachment[] Attachments { get; set; } = Array.Empty<MessageAttachment>();

    [JsonProperty("embeds")]
    public MessageEmbed[] Embeds { get; set; } = Array.Empty<MessageEmbed>();

    [JsonProperty("mentions")]
    public User[] Mentions { get; set; } = Array.Empty<User>();
    
    [JsonProperty("member")]
    public Member CreatorMemberInfo { get; set; } = Member.Empty;

    [JsonProperty("ark")]
    public MessageArk Ark { get; set; } = new MessageArk();
    
    [JsonProperty("seq")]
    public int Sequence { get; set; }
    
    [JsonProperty("seq_in_channel")]
    public int SequenceInChannel { get; set; }

    [JsonProperty("message_reference")]
    public MessageReference Reference { get; set; } = new MessageReference();

    [JsonProperty("src_guild_id")]
    public string SourceGuildId { get; set; } = "";

    public static Message Empty { get; }= new Message();

    private static Regex _atPattern = new Regex(@"<@!(\d+)>\s?");
    public void RemoveAtString()
    {
        StringBuilder replacedMsg = new StringBuilder(Content);
            MatchCollection collection = _atPattern.Matches(Content);
        foreach (Match match in collection)
        {
            if (!match.Success)
            {
                continue;
            }

            string key = match.Groups[1].Value;
            if (Mentions.Any(u => u.Id == key))
            {
                replacedMsg.Replace(match.Groups[0].Value, "");
            }
        }

        Content = replacedMsg.ToString();
    }
}