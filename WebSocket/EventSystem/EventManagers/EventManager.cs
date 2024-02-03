using QqGuildRobotSdk.WebSocket.EventSystem.EventRegisters;
using QqGuildRobotSdk.WebSocket.EventSystem.Events;

namespace QqGuildRobotSdk.WebSocket.EventSystem.EventManagers;

public class EventManager : IEventManager<string>
{
    private readonly Dictionary<string, IEventRegister<string>> _events = new Dictionary<string, IEventRegister<string>>();
    public IEvent? GetEvent(Type t, string id)
    {
        var e = GetEventByName(id);
        return e == null ? null : e.GetType() == t ? e : null;
    }

    public TEvent? GetEvent<TEvent>(string id) where TEvent: IEvent
    {
        var e = GetEventByName(id);
        return e is TEvent ev ? ev : default;
    }

    public TEvent? GetEvent<TEvent, TEventData>(string id) where TEvent : IEvent
    {
        return (TEvent?)(IEvent<string, TEventData>?)GetEvent<TEvent>(id);
    }

    public IEvent? GetEventByName(string id)
    {
        _events.TryGetValue(id, out var result);
        return result?.Event;
    }
    

    public IEventRegister<string> RegisterEvent(string id, IEvent e)
    {
        if (_events.TryGetValue(id, out var registeredEvent))
        {
            return registeredEvent;
        }

        var eventRegister = new EventRegister(id, e);
        _events.Add(id, eventRegister);
        return new EventRegister(id, e);
    }

    public IEventRegister<string> ReplaceEvent(string id, IEvent e)
    {
        if (!_events.TryGetValue(id, out var value))
        {
            throw new KeyNotFoundException($"No key {id} found");
        }

        var oldVal = value;
        var nVal =  new EventRegister(id, e);
        _events[id] = nVal;
        return oldVal;

    }

    public void UnregisterEvent(string id)
    {
        _events.Remove(id);
    }
}



