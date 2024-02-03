using QqGuildRobotSdk.Audio;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Audio;

public class AudioOnMicPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        AudioAction? audioAction = packet.Data?.ToObject<AudioAction>();
        if (audioAction == null)
        {
            return;
        }
        
        var eventData = audioAction;
        const string eventName = QqGuildEventKeys.AudioTurnOnMic;
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<AudioEventArgs>>(eventName);
        e?.Raise(new AudioEventArgs(client, packet, eventData));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "AUDIO_ON_MIC";
}