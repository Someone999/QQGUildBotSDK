using QqGuildRobotSdk.WebSocket.Events.EventArgs;

namespace QqGuildRobotSdk.WebSocket.Events;

public class AudioEvents
{
    public QqGuildWebSocketEvent<AudioEventArgs>? OnAudioStart { get; set; }
    public QqGuildWebSocketEvent<AudioEventArgs>? OnAudioFinish { get; set; }
    public QqGuildWebSocketEvent<AudioEventArgs>? OnAudioOnMic { get; set; }
    public QqGuildWebSocketEvent<AudioEventArgs>? OnAudioOffMic { get; set; }
}