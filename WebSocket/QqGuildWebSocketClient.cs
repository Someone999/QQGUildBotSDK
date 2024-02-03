using System.Text;
using Newtonsoft.Json;
using QqGuildRobotSdk.Authenticate;
using QqGuildRobotSdk.Roles;
using QqGuildRobotSdk.Sdk;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.EventSystem.EventManagers;
using QqGuildRobotSdk.WebSocket.EventSystem.Events;
using QqGuildRobotSdk.WebSocket.PacketHandlers;
using QqGuildRobotSdk.WebSocket.PacketHandlers.Server;
using QqGuildRobotSdk.WebSocket.Packets;
using QqGuildRobotSdk.WebSocket.Packets.ClientPackets;
using QqGuildRobotSdk.WebSocket.Packets.ServerPackets;
using WebSocket4Net;
using ErrorEventArgs = SuperSocket.ClientEngine.ErrorEventArgs;
using Timer = System.Timers.Timer;

namespace QqGuildRobotSdk.WebSocket;

public class QqGuildWebSocketClient
{
    public IRoleConverter RoleConverter { get; set; } = new DefaultRoleConverter();
    public QqGuildWebSocketClientInfo ClientInfo { get; } 
    public PacketManager PacketManager { get; } = new PacketManager();
    public QqGuildBotSdk Sdk { get; }
    public IEventManager<string> EventManager { get; } = new QqGuildSdkEventManager();
    public QqGuildWebSocketClient(QqGuildWebSocketClientCreateParameters parameters)
    {
        Identifier = parameters.Identifier;
        WebSocket = new WebSocket4Net.WebSocket(parameters.WssUrl);
        Sdk = QqGuildBotSdk.GetSdk(parameters.Identifier);
        ClientInfo = new QqGuildWebSocketClientInfo(Identifier);
        ClientInfo.CreateParameters = parameters;
        _heartbeatKeeper = new QqGuideBotWebSocketClientHeartbeatKeeper(this);
        EventInitializer.InitializeEvent(EventManager);
        UseSandboxEnvironment = parameters.UseSandboxEnvironment;
        if (parameters.AutoStart)
        {
            Start();
        }
    }
    internal readonly WebSocket4Net.WebSocket WebSocket;

    private readonly QqGuideBotWebSocketClientHeartbeatKeeper _heartbeatKeeper;
    public BotIdentifier Identifier { get; }
    private static readonly string FormalUrl = "https://api.sgroup.qq.com/";
    private static readonly string SandboxUrl = "https://sandbox.api.sgroup.qq.com/";
    string GetBaseUrl() => UseSandboxEnvironment
        ? SandboxUrl
        : FormalUrl;
    public bool UseSandboxEnvironment { get; set; }
    private bool _started;
    public bool Connected => WebSocket.State == WebSocketState.Open;
    public void Start()
    {
        if (_started)
        {
            return;
        }
        
        WebSocket.Open();
        WebSocket.MessageReceived += WebSocketOnMessageReceived;
        WebSocket.Closed += OnClosed;
        WebSocket.Error += OnError;
        WebSocket.DataReceived += OnDataReceived;
        _started = true;
    }

    private void OnStop()
    {
        if (!_started)
        {
            return;
        }
        WebSocket.MessageReceived -= WebSocketOnMessageReceived;
        WebSocket.Closed -= OnClosed;
        WebSocket.Error -= OnError;
        WebSocket.DataReceived -= OnDataReceived;
        _heartbeatKeeper.StopSend();
        _started = false;
    }

    public event EventHandler<DataReceivedEventArgs>? OnDataReceived; 
    public event EventHandler<ErrorEventArgs>? OnError;
    public event EventHandler? OnClosed; 
    

    public void Stop()
    {
        if (!_started)
        {
            return;
        }
        
        WebSocket.Close();
        OnStop();
    }
    
    private void WebSocketOnMessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        string json = e.Message;
        ServerPacketBase? basePacket = JsonConvert.DeserializeObject<ServerPacketBase>(json);
        if (basePacket == null)
        {
            return;
        }
        
        lock (PacketManager)
        {
            PacketManager.LastPacket = basePacket;
            PacketManager.Packets.Add(basePacket);
        }

       
        var handler = PacketHandlerManager.GetHandler(basePacket.OperationCode, basePacket.SubEventType);
        if (handler == null)
        {
            if (PacketManager.ValidPacketOpCodes.Contains((int)basePacket.OperationCode))
            {
                EventManager.GetEvent<GenericEvent<ServerPacketBase>>
                    (QqGuildEventKeys.UnhandledPacket)?.Raise(basePacket);
            }
            else
            {
                EventManager.GetEvent<GenericEvent<ServerPacketBase>>
                    (QqGuildEventKeys.UndefinedPacket)?.Raise(basePacket);
            }
            return;
        }
        
        handler.Handle(this, basePacket);
        if (handler is not HelloPacketHandler || _heartbeatKeeper.IsRunning)
        {
            return;
        }
        _heartbeatKeeper.SendInterval = basePacket.Data?["heartbeat_interval"]?.ToObject<int>() ?? 41250;
        _heartbeatKeeper.StartSend();
    }

}