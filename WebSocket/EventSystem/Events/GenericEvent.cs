using QqGuildRobotSdk.WebSocket.EventSystem.BoundEventHandlers;

namespace QqGuildRobotSdk.WebSocket.EventSystem.Events;


public class GenericEvent<TEventData> : IEvent<string, TEventData>
{
    private readonly Dictionary<string, IBoundEventHandler> _boundEventHandlers = new();
    
    IBoundEventHandler IEvent.Bind(Delegate d)
    {
        if (d is not EventHandler<TEventData> eventHandler)
        {
            throw new InvalidOperationException();
        }

        return Bind(eventHandler);
    }

    void IEvent.Unbind(object id)
    {
        if (id is not string s)
        {
            throw new InvalidOperationException();
        }

        Unbind(s);
    }

    void IEvent.Raise(object eventArgs)
    {
        if (eventArgs is not TEventData eventData)
        {
            throw new InvalidOperationException();
        }
        
        Raise(eventData);
    }

    public IBoundEventHandler<string, TEventData> Bind(EventHandler<TEventData> eventHandler)
    {
        string guid = Guid.NewGuid().ToString();
        BoundEventHandler<string, TEventData> boundEventHandler = 
            new BoundEventHandler<string, TEventData>(guid, eventHandler);

        _boundEventHandlers.Add(guid, boundEventHandler);
        return boundEventHandler;
    }

    public void Unbind(string id)
    {
        _boundEventHandlers.Remove(id);
    }

    public void Raise(TEventData eventArgs)
    {
        foreach (var boundEventHandler in _boundEventHandlers)
        {
            boundEventHandler.Value.EventHandler.DynamicInvoke(this, eventArgs);
        }
    }
}
