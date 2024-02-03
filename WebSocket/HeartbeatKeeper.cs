namespace QqGuildRobotSdk.WebSocket;

public abstract class HeartbeatKeeper<TClient>
{
    protected TClient Client;

    protected HeartbeatKeeper(TClient client)
    {
        Client = client;
    }

    public virtual double SendInterval { get; set; } = 45 * 1000;
    public abstract bool IsRunning { get; protected set; }
    public abstract void StartSend();
    public abstract void StopSend();
    public abstract event HeartbeatSentEventHandler<TClient>? OnHeartbeatSent;
    protected abstract void Send();
}