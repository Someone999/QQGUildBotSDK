using QqGuildRobotSdk.WebSocket.EventSystem.Events;

namespace QqGuildRobotSdk.WebSocket.EventSystem.EventRegisters;

public class EventRegister : IEventRegister<string>
{
    public EventRegister(string eventId, IEvent e)
    {
        EventId = eventId;
        Event = e;
    }

    public string EventId { get; }
    public IEvent Event { get; }
    public TEvent GetEventAs<TEvent>() where TEvent : IEvent => (TEvent)Event;
}