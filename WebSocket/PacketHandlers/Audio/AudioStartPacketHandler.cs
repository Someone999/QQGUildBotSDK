using QqChannelRobotSdk.Audio;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.PacketHandlers.Audio;

public class AudioStartPacketHandler : IPacketHandler
{
    public void Handle(QqGuildWebSocketClient client, ServerPacketBase packet)
    {
        AudioAction? audioAction = packet.Data?.ToObject<AudioAction>();
        if (audioAction == null)
        {
            return;
        }
        
        client.EventManager.AudioEvents.OnAudioStart?.Invoke(client, new AudioEventArgs(packet, audioAction));
    }
    public OperationCode Code => OperationCode.Dispatch;
    public string? SubEventType => "AUDIO_START";
}