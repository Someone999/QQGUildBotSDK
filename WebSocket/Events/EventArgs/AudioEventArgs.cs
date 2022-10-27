using QqGuildRobotSdk.Audio;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqGuildRobotSdk.WebSocket.Events.EventArgs;

public class AudioEventArgs : EventArgBase
{
    public AudioEventArgs(QqGuildWebSocketClient client, ServerPacketBase packetBase, AudioAction audioAction) : base(client, packetBase)
    {
        AudioAction = audioAction;
    }
    public AudioAction AudioAction { get; }
}