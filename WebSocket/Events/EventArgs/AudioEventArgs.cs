using QqChannelRobotSdk.Audio;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk.WebSocket.Events.EventArgs;

public class AudioEventArgs
{
    public AudioEventArgs(ServerPacketBase packetBase, AudioAction audioAction)
    {
        AudioAction = audioAction;
        PacketBase = packetBase;
    }
    public AudioAction AudioAction { get; }
    public ServerPacketBase PacketBase { get; }
}