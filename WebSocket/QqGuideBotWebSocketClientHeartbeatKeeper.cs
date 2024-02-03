using System.Timers;
using Newtonsoft.Json;
using QqGuildRobotSdk.WebSocket.Packets.ClientPackets;
using WebSocket4Net;
using Timer = System.Timers.Timer;

namespace QqGuildRobotSdk.WebSocket;

public class QqGuideBotWebSocketClientHeartbeatKeeper : HeartbeatKeeper<QqGuildWebSocketClient>
{
    public QqGuideBotWebSocketClientHeartbeatKeeper(QqGuildWebSocketClient client) : base(client)
    {
        _sendTimer.Elapsed += OnTimerElapsed;
        _sendTimer.AutoReset = true;
    }

    private Timer _sendTimer = new Timer();

    public override double SendInterval
    {
        get => _sendTimer.Interval;
        set => _sendTimer.Interval = value;
    }

    public override bool IsRunning { get; protected set; }

    private void CheckState()
    {
        if (Client.WebSocket.State != WebSocketState.Open)
        {
            throw new InvalidOperationException("The heartbeat cannot be sent on a connection that is not opened.");
        }
    }
    public override void StartSend()
    {
        if (IsRunning)
        {
            return;
        }

        CheckState();
        _sendTimer.Start();
        IsRunning = true;
    }

    public override void StopSend()
    {
        if (!IsRunning || Client.WebSocket.State != WebSocketState.Open)
        {
            return;
        }
        
        _sendTimer.Stop();
        IsRunning = false;
    }

    public override event HeartbeatSentEventHandler<QqGuildWebSocketClient>? OnHeartbeatSent;

    private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
    {
        Send();
    }

    protected override void Send()
    {
        var seq = Client.PacketManager.LastPacket?.Sequence;
        HeartbeatPacket heartbeatPacket = new HeartbeatPacket(seq);
        Client.WebSocket.Send(
            JsonConvert.SerializeObject(heartbeatPacket));
        OnHeartbeatSent?.Invoke(this, new HeartbeatSentEventData<QqGuildWebSocketClient>(Client));
    }
}