using QqGuildRobotSdk.Models.Forums;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem.EventManagers;
using QqGuildRobotSdk.WebSocket.EventSystem.Events;
using QqGuildRobotSdk.WebSocket.PacketHandlers.Forum.Post;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.EventSystem;

public static class EventInitializer
{
    public static void InitializeEvent(IEventManager<string> eventManager)
    {
        eventManager.RegisterEvent(QqGuildEventKeys.WebSocketReadied, new GenericEvent<ReadyPacketData>());
        eventManager.RegisterEvent(QqGuildEventKeys.WebSocketFailed, new GenericEvent<PacketReceivedEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.UndefinedPacket, new GenericEvent<ServerPacketBase>());
        eventManager.RegisterEvent(QqGuildEventKeys.AudioStartEvent, new QqGuildSdkEvent<AudioEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.AudioFinishEvent, new QqGuildSdkEvent<AudioEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.AudioTurnOffMicEvent, new QqGuildSdkEvent<AudioEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.AudioTurnOnMic, new QqGuildSdkEvent<AudioEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.ForumPostCreate, new QqGuildSdkEvent<ForumPostEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.ForumPostDelete, new QqGuildSdkEvent<ForumPostEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.ForumReplyCreate, new QqGuildSdkEvent<ForumReplyEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.ForumReplyDelete, new QqGuildSdkEvent<ForumReplyEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.ForumPublishAuditResult,
            new QqGuildSdkEvent<ForumPublishAuditResultArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.ForumThreadCreate, new QqGuildSdkEvent<ForumThreadEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.ForumThreadDelete, new QqGuildSdkEvent<ForumThreadEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.ForumThreadUpdate, new QqGuildSdkEvent<ForumThreadEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildChannelCreate, new QqGuildSdkEvent<ChannelEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildChannelDelete, new QqGuildSdkEvent<ChannelEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildChannelUpdate, new QqGuildSdkEvent<ChannelEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildDirectMessageCreate,
            new QqGuildSdkEvent<DirectCreateMessageEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildMessageReactionAdd,
            new QqGuildSdkEvent<DirectDeleteMessageEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildMemberJoined, new QqGuildSdkEvent<GuildMemberEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildMemberRemoved, new QqGuildSdkEvent<GuildMemberEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildMemberInfoUpdated,
            new QqGuildSdkEvent<GuildMemberEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildMessageReactionAdd, new QqGuildSdkEvent<MessageReactionEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildMessageReactionRemove, new QqGuildSdkEvent<MessageReactionEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildCreate, new QqGuildSdkEvent<GuildEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildDelete, new QqGuildSdkEvent<GuildEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.GuildUpdate, new QqGuildSdkEvent<GuildEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.MessageAuditPassed, new QqGuildSdkEvent<MessageAuditEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.MessageAuditRejected, new QqGuildSdkEvent<MessageAuditEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.AtMessageCreate, new QqGuildSdkEvent<MessageCreateEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.MessageCreate, new QqGuildSdkEvent<MessageCreateEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.MessageDelete, new QqGuildSdkEvent<MessageDeleteEventArgs>());
        eventManager.RegisterEvent(QqGuildEventKeys.PublicMessageDelete, new QqGuildSdkEvent<MessageDeleteEventArgs>());
        
    }
}