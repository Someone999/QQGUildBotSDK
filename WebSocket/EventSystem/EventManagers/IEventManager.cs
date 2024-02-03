using QqGuildRobotSdk.WebSocket.EventSystem.EventRegisters;
using QqGuildRobotSdk.WebSocket.EventSystem.Events;

namespace QqGuildRobotSdk.WebSocket.EventSystem.EventManagers;

public interface IEventManager<TId>
{
    IEvent? GetEvent(Type t, TId id);
    TEvent? GetEvent<TEvent>(TId id) where TEvent: IEvent;
    TEvent? GetEvent<TEvent, TEventData>(TId id) where TEvent: IEvent;
    IEvent? GetEventByName(TId id);
    IEventRegister<TId> RegisterEvent(TId id, IEvent e);
    IEventRegister<TId> ReplaceEvent(TId id, IEvent e);
    void UnregisterEvent(TId id);
}

