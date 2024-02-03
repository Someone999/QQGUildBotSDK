using HsManCommonLibrary.Configuration;
using HsManCommonLibrary.NestedValues.NestedValueAdapters;
using HsManCommonLibrary.NestedValues.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QqGuildRobotSdk.Authenticate;
using QqGuildRobotSdk.Configs;
using QqGuildRobotSdk.WebSocket;
using QqGuildRobotSdk.WebSocket.Events;
using QqGuildRobotSdk.WebSocket.Events.EventArgs;
using QqGuildRobotSdk.WebSocket.EventSystem;
using QqGuildRobotSdk.WebSocket.Models;
using QqGuildRobotSdk.WebSocket.Utils;

namespace QqGuildRobotSdk;


public class Program
{
    static readonly ConfigurationRegistryCenter RegistryCenter = new ConfigurationRegistryCenter();
    public static MainConfig MainConfig { get; } = new MainConfig(); 
    static void InitConfig()
    {
        string configFile = "./config.json";
        string jsonData = File.ReadAllText(configFile);
        JToken? jsonConfig = JsonConvert.DeserializeObject<JToken>(jsonData);
        var configNestedValue = new JsonNestedValueStoreAdapter().ToNestedValue(jsonConfig);
        RegistryCenter.RegisterConfig("mainConfig", configNestedValue);
        ObjectAssigner.AssignTo(MainConfig, RegistryCenter["mainConfig"], new AssignOptions());
    }
    static void Main(string[] args)
    {
        InitConfig();
        string secretKey = MainConfig.BotSecret;
        string botToken = MainConfig.BotToken;
        string botAppId = MainConfig.BotAppId;
        BotIdentifier identifier = new BotIdentifier(botAppId, secretKey, botToken);
        var r = QqGuildWebSocketConnectionUtils
            .GetMultiShardConnectionUrl(new QqGuildWssUrlRequest(identifier)
            {
                //UseSandboxEnvironment = true
            }).Result;
        var createParams = new QqGuildWebSocketClientCreateParameters(identifier);
        createParams.RegisteredEvents = PrimaryEventType.GuildMessages | PrimaryEventType.Guilds;
        createParams.AutoStart = true;
        createParams.UseSandboxEnvironment = true;
        var client = new QqGuildWebSocketClient(new QqGuildWebSocketClientCreateParameters(identifier)
        {
            AutoStart = true,
            MaxShardCount = 1,
            RegisteredEvents = PrimaryEventType.GuildMessages,
            UseSandboxEnvironment = true,
            WssUrl = r.ResponseObject!.Url
        });
        var e = client.EventManager.GetEvent<QqGuildSdkEvent<MessageCreateEventArgs>>(QqGuildEventKeys.MessageCreate);
        e?.Bind(((sender, eventArgs) =>
        {
            Console.WriteLine(eventArgs.Message.Content);
        }));

        while (true) ;
    }
}