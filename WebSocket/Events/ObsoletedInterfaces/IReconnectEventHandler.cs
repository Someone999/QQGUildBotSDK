using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.WebSocket.Events;

public interface IReconnectEventHandler : IEventHandler<ReconnectEventArgs>
{
}