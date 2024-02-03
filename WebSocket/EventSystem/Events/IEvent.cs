using QqGuildRobotSdk.WebSocket.EventSystem.BoundEventHandlers;

namespace QqGuildRobotSdk.WebSocket.EventSystem.Events;

public interface IEvent
{
    IBoundEventHandler Bind(Delegate d);
    void Unbind(object id);
    void Raise(object eventArgs);
}

public interface IEvent<TId>  : IEvent
{
    new IBoundEventHandler<TId> Bind(Delegate d);
    void Unbind(TId id);
}

public interface IEvent<TId, TEventData>  : IEvent
{
    IBoundEventHandler<TId, TEventData> Bind(EventHandler<TEventData> eventHandler);
    void Unbind(TId id);
    void Raise(TEventData eventArgs);
}
