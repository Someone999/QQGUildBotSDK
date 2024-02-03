using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem.Events;


namespace QqGuildRobotSdk.WebSocket.Events;

public class QqGuildSdkEvent<TEventArg> : GenericEvent<TEventArg> where TEventArg: EventArgBase
{
}