using System.Text;
using Newtonsoft.Json;
using QqGuildRobotSdk.Authenticate;
using QqGuildRobotSdk.Roles;
using QqGuildRobotSdk.Sdk;
using QqGuildRobotSdk.WebSocket.Events;
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
    private static Dictionary<BotIdentifier, Dictionary<int, QqGuildWebSocketClient>> _createdClients =
        new Dictionary<BotIdentifier, Dictionary<int, QqGuildWebSocketClient>>();

    private static object Locker { get; } = new();
    
    /// <summary>
    /// 创建或者用<see cref="BotIdentifier"/>从对象池获取一个Dictionary&lt;int, QqGuildWebSocketClient&gt;
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static Dictionary<int, QqGuildWebSocketClient> CreateClients(QqGuildWebSocketClientCreateParameters parameters)
    {
        lock (Locker)
        {
            if (_createdClients.ContainsKey(parameters.Identifier))
            {
                return _createdClients[parameters.Identifier];
            }
            
            Dictionary<int, QqGuildWebSocketClient> clients = new Dictionary<int, QqGuildWebSocketClient>();
            for (int currentShardCount = 0; currentShardCount < parameters.MaxShardCount; currentShardCount++)
            {
                QqGuildWebSocketClient currentClient = new QqGuildWebSocketClient(parameters.Identifier, parameters.WssUrl)
                {
                    ClientInfo =
                    {
                        CreateParameters = parameters,
                        CurrentShard = currentShardCount
                    }
                };

                if (parameters.AutoStart)
                {
                    currentClient.Start();
                }
                
                clients.Add(currentShardCount, currentClient);
            }
            _createdClients.Add(parameters.Identifier, clients);
            return clients;
        }
    }


    public IRoleConverter RoleConverter { get; set; } = new DefaultRoleConverter();
    public QqGuildWebSocketClientInfo ClientInfo { get; } 
    public PacketManager PacketManager { get; } = new PacketManager();
    public QqGuildBotSdk Sdk { get; }
    public EventManager EventManager { get; } = new EventManager();
    private QqGuildWebSocketClient(BotIdentifier identifier, string wssUrl)
    {
        Identifier = identifier;
        WebSocket = new WebSocket4Net.WebSocket(wssUrl);
        Sdk = QqGuildBotSdk.GetSdk(identifier);
        ClientInfo = new QqGuildWebSocketClientInfo(Identifier);
    }
    internal readonly WebSocket4Net.WebSocket WebSocket;
    private readonly Timer _heartbeatTimer = new Timer();
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
        WebSocket.Closed += WebSocketOnClosed;
        WebSocket.Error += WebSocketOnError;
        WebSocket.DataReceived += WebSocketOnDataReceived;
        _started = true;
    }

    private void OnStop()
    {
        if (!_started)
        {
            return;
        }
        WebSocket.MessageReceived -= WebSocketOnMessageReceived;
        WebSocket.Closed -= WebSocketOnClosed;
        WebSocket.Error -= WebSocketOnError;
        WebSocket.DataReceived -= WebSocketOnDataReceived;
        _heartbeatTimer.Stop();
        _started = false;
    }
    
    private void WebSocketOnDataReceived(object? sender, DataReceivedEventArgs e)
    {
        Console.WriteLine($"接收到数据: {Encoding.Default.GetString(e.Data)}");
    }
    
    private void WebSocketOnClosed(object? sender, EventArgs e)
    {
        Console.WriteLine("连接意外断开");
        OnStop();
    }
    private void WebSocketOnError(object? sender, ErrorEventArgs e)
    {
        Console.WriteLine($"遇到错误: {e.Exception.Message}");
        if (WebSocket.State == WebSocketState.Closed)
        {
            OnStop();
        }
    }

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
                Console.WriteLine($"未处理的包: {basePacket.OperationCode} -> {basePacket.SubEventType}");
                Console.WriteLine(json);
                Console.WriteLine("------------------");
            }
            else
            {
                Console.WriteLine($"未知的包类型: {(int)basePacket.OperationCode} -> {basePacket.SubEventType}");
            }
            return;
        }
        
        handler.Handle(this, basePacket);
        if (handler is not HelloPacketHandler || _heartbeatTimer.Enabled)
        {
            return;
        }
        _heartbeatTimer.Interval = basePacket.Data?["heartbeat_interval"]?.ToObject<int>() ?? 41250;
        _heartbeatTimer.Elapsed += (_, _) => 
            WebSocket.Send(JsonConvert.SerializeObject(new HeartbeatPacket(PacketManager.LastHasSequencePacket?.Sequence)));
        _heartbeatTimer.Start();

    }

}