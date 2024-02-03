namespace QqGuildRobotSdk.WebSocket;

public class HeartbeatSentEventData<TClient>
{
    public HeartbeatSentEventData(TClient client)
    {
        Client = client;
    }

    public DateTime SendTime { get; } = new DateTime();
    public TClient Client { get; }
}