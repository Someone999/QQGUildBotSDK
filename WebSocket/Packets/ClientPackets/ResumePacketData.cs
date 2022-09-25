using Newtonsoft.Json;

namespace QqChannelRobotSdk.WebSocket.Packets.ClientPackets;

public class ResumePacketData
{
    [JsonProperty("token")]
    public string Token { get; set; } = "";

    [JsonProperty("session_id")]
    public string SessionId { get; set; } = "";
    
    [JsonProperty("seq")]
    public int Sequence { get; set; }
}