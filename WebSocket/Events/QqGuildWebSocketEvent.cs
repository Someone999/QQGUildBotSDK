namespace QqGuildRobotSdk.WebSocket.Events;

public delegate void QqGuildWebSocketEvent<in T>(QqGuildWebSocketClient socketClient, T eventArgs);