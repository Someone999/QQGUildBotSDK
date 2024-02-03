namespace QqGuildRobotSdk.WebSocket.EventSystem.BoundEventHandlers;

public class BoundEventHandler : IBoundEventHandler
{
    public BoundEventHandler(object id, Delegate eventHandler)
    {
        Id = id;
        EventHandler = eventHandler;
    }

    public object Id { get; }
    public Delegate EventHandler { get; }
}
public class BoundEventHandler<TId> :
    IBoundEventHandler<TId>
{
    public BoundEventHandler(TId id, Delegate eventHandler)
    {
        Id = id;
        EventHandler = eventHandler;
    }

    public TId Id { get; }

    public Delegate EventHandler { get; }

    object IBoundEventHandler.Id => Id ?? throw new InvalidOperationException();
}

public class BoundEventHandler<TId, TEventData> :
    IBoundEventHandler<TId, TEventData>
{
    public BoundEventHandler(TId id, EventHandler<TEventData> eventHandler)
    {
        Id = id;
        EventHandler = eventHandler;
    }

    public TId Id { get; }
    Delegate IBoundEventHandler.EventHandler => EventHandler;

    object IBoundEventHandler.Id => Id ?? throw new InvalidOperationException();
    public EventHandler<TEventData> EventHandler { get; }
}
