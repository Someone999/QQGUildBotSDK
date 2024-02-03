using QqGuildRobotSdk.WebSocket.EventSystem.Events;

namespace QqGuildRobotSdk.WebSocket.EventSystem.EventRegisters;

public interface IEventRegister<out TId>
{
    TId EventId { get; }
    IEvent Event { get; }
    TEvent GetEventAs<TEvent>() where TEvent: IEvent;
}