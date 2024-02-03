namespace QqGuildRobotSdk.WebSocket.EventSystem.BoundEventHandlers;

public interface IBoundEventHandler
{
    object Id { get; }
    Delegate EventHandler { get; }
}

public interface IBoundEventHandler<out TId> : IBoundEventHandler
{
    new TId Id { get; }
}

public interface IBoundEventHandler<out TId, TEventData> : IBoundEventHandler<TId>
{
    new EventHandler<TEventData> EventHandler { get; }
}

