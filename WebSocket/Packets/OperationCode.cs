namespace QqChannelRobotSdk.WebSocket.Packets;

public enum OperationCode
{
    Dispatch,
    Heartbeat,
    Identify,
    Resume = 6,
    Reconnect,
    InvalidSession = 9,
    Hello,
    HeartbeatAck,
    HttpCallbackAck
}