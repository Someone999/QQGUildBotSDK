using QqGuildRobotSdk.Audio;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers.Audio;

public class AudioFinishPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        AudioAction? audioAction = packet.Data?.ToObject<AudioAction>();
        if (audioAction == null)
        {
            return;
        }
        
        client.EventManager.AudioEvents.OnAudioStart?.Invoke(client, new AudioEventArgs(client, packet, audioAction));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "AUDIO_FINISH";
}