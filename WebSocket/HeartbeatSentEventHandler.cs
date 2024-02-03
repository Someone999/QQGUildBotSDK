namespace QqGuildRobotSdk.WebSocket;

public delegate void HeartbeatSentEventHandler<TClient>(object? sender, HeartbeatSentEventData<TClient> data);