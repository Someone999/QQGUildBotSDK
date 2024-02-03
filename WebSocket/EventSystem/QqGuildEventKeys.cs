using QqGuildRobotSdk.Attributes;

namespace QqGuildRobotSdk.WebSocket.EventSystem;

public static class QqGuildEventKeys
{
    public const string UnhandledPacket = "SystemEvent.UnhandledPacket";
    public const string UndefinedPacket = "SystemEvent.UndefinedPacket";
    public const string WebSocketReadied = "SystemEvent.WebSocketReadied";
    public const string WebSocketFailed = "SystemEvent.WebSocketFailed";
    public const string AudioFinishEvent = "QqGuildEvent.Audio.Finish";
    public const string AudioStartEvent = "QqGuildEvent.Audio.Start";
    public const string AudioTurnOffMicEvent = "QqGuildEvent.Audio.TrunOffMic";
    public const string AudioTurnOnMic = "QqGuildEvent.Audio.TurnOnMic";
    public const string ForumPostCreate = "QqGuildEvent.Forum.Post.Create";
    public const string ForumPostDelete = "QqGuildEvent.Forum.Post.Delete";
    public const string ForumReplyCreate = "QqGuildEvent.Forum.Reply.Create";
    public const string ForumReplyDelete = "QqGuildEvent.Forum.Reply.Delete";
    public const string ForumPublishAuditResult = "QqGuildEvent.Forum.PublishAuditResult";
    public const string ForumThreadCreate = "QqGuildEvent.Forum.Thread.Create";
    public const string ForumThreadDelete = "QqGuildEvent.Forum.Thread.Delete";
    public const string ForumThreadUpdate = "QqGuildEvent.Forum.Thread.Update";
    public const string GuildChannelCreate = "QqGuildEvent.Guild.Channel.Create";
    public const string GuildChannelDelete = "QqGuildEvent.Guild.Channel.Delete";
    public const string GuildChannelUpdate = "QqGuildEvent.Guild.Channel.Update";
    public const string GuildDirectMessageCreate = "QqGuildEvent.DirectMessage.Create";
    public const string GuildDirectMessageRemove = "QqGuildEvent.DirectMessage.Remove";
    public const string GuildMemberJoined = "QqGuildEvent.Member.Joined";
    public const string GuildMemberRemoved = "QqGuildEvent.Member.Removed";
    public const string GuildMemberInfoUpdated = "QqGuildEvent.Member.InfoUpdated";
    public const string GuildMessageReactionAdd = "QqGuildEvent.Guild.MessageReaction.Add";
    public const string GuildMessageReactionRemove = "QqGuildEvent.Guild.MessageReaction.Remove";
    public const string GuildCreate = "QqGuildEvent.Guild.Create";
    public const string GuildDelete = "QqGuildEvent.Guild.Delete";
    public const string GuildUpdate = "QqGuildEvent.Guild.Update";
    public const string MessageAuditPassed = "QqGuildEvent.Guild.MessageAuditPassed";
    public const string MessageAuditRejected = "QqGuildEvent.Guild.MessageAuditRejected";
    
    [WorkInProgress("I currently do not have a structural definition for event data.")]
    public const string InteractionMessageCreate = "QqGuildEvent.Message.Interaction.Create";
    public const string AtMessageCreate = "QqGuildEvent.Message.At.Create";
    public const string MessageCreate = "QqGuildEvent.Message.Create";
    public const string MessageDelete = "QqGuildEvent.Message.Delete";
    public const string PublicMessageDelete = "QqGuildEvent.Message.Public.Delete";
    
    [InternalUseOnly("No code will raise this event currently.")]
    public const string HeartbeatAck = "QqGuildEvent.Server.HeartbeatAck";
    
    [InternalUseOnly("No code will raise this event currently.")]
    public const string InvalidSession = "QqGuildEvent.Server.InvalidSession";
    
    [InternalUseOnly("No code will raise this event currently.")]
    public const string Reconnect = "QqGuildEvent.Server.Reconnect";
    
    [InternalUseOnly("No code will raise this event currently.")]
    public const string Resume = "QqGuildEvent.Server.Resume";
}