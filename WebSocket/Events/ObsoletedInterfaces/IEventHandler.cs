using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.Models;

namespace QqChannelRobotSdk.WebSocket.Events;

public interface IEventHandler<in TEventArg>
{
    void Handle(QqGuildWebSocketClient client, TEventArg? arg);
}