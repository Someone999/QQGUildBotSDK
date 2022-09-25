namespace QqChannelRobotSdk.WebSocket.Events;

public delegate void QqGuildWebSocketEvent<in T>(QqGuildWebSocketListener socketListener, T eventArgs);