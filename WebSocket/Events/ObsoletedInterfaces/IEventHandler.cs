namespace QqChannelRobotSdk.WebSocket.Events.ObsoletedInterfaces;

public interface IEventHandler<in TEventArg>
{
    void Handle(QqGuildWebSocketClient client, TEventArg? arg);
}