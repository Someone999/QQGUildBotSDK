using System.Security.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QqChannelRobotSdk.Authenticate;
using QqChannelRobotSdk.Sdk;
using QqChannelRobotSdk.WebSocket.Events;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.PacketHandlers;
using QqChannelRobotSdk.WebSocket.PacketHandlers.Server;
using QqChannelRobotSdk.WebSocket.Packets;
using QqChannelRobotSdk.WebSocket.Packets.ClientPackets;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;
using WebSocket4Net;
using Timer = System.Timers.Timer;

namespace QqChannelRobotSdk.WebSocket;

public class QqGuildWebSocketClient
{
    public QqGuildBotSdk Sdk { get; }
    public EventManager EventManager { get; } = new EventManager();
    public QqGuildWebSocketClient(BotIdentifier identifier)
    {
        var httpClient = identifier.GetBotTokenAuthenticateHttpClient();
        Identifier = identifier;
        string url = GetBaseUrl() + "gateway";
        string wssUrlJson = httpClient.GetStringAsync(url).Result;
        JObject jObj = JsonConvert.DeserializeObject<JObject>(wssUrlJson) ?? new JObject();
        if (!jObj.ContainsKey("url"))
        {
            throw new Exception("Failed to get wss url");
        }

        string wssUrl = jObj["url"]?.ToObject<string>() ?? throw new Exception("Failed to get wss url");
        WebSocket = new WebSocket4Net.WebSocket(wssUrl);
        Sdk = QqGuildBotSdk.GetSdk(identifier);
        
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
    public PrimaryEventType RegisteredEvent { get; set; } = PrimaryEventType.None;
    private bool _started;
    public bool Connected => WebSocket.State == WebSocketState.Open;
    public void Start()
    {
        WebSocket.Open();
        if (_started)
        {
            _heartbeatTimer.Start();
        }
        _started = true;
        WebSocket.MessageReceived += WebSocketOnMessageReceived;
        
    }

    public void Stop()
    {
        WebSocket.Close();
        WebSocket.MessageReceived -= WebSocketOnMessageReceived;
        _heartbeatTimer.Stop();
    }
    
    private void WebSocketOnMessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        string json = e.Message;
        ServerPacketBase? basePacket = JsonConvert.DeserializeObject<ServerPacketBase>(json);
        if (basePacket == null)
        {
            return;
        }
        
        lock (PacketManager.Locker)
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
        if (handler is not HelloPacketHandler helloPacketHandler || _heartbeatTimer.Enabled)
        {
            return;
        }
        _heartbeatTimer.Interval = basePacket.Data?["heartbeat_interval"]?.ToObject<int>() ?? 41250;
        _heartbeatTimer.Elapsed += (_, _) => WebSocket.Send(JsonConvert.SerializeObject(new HeartbeatPacket()));
        _heartbeatTimer.Start();

    }

}