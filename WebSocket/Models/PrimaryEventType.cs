namespace QqChannelRobotSdk.WebSocket.Models;

[Flags]
public enum PrimaryEventType
{
    None = 0,
    Guilds = 1 << 0,
    GuildMembers = 1 << 1,
    GuildMessages = 1 << 9,
    GuildMessageReactions = 1 << 10,
    DirectMessage = 1 << 12,
    Interaction = 1 << 26,
    MessageAudit = 1 << 27,
    ForumsEvent = 1 << 28,
    AudioAction = 1 << 29,
    PublicGildMessages = 1 << 30
    
}