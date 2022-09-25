using Newtonsoft.Json;
using QqChannelRobotSdk.Authenticate;
using QqChannelRobotSdk.Request;
using QqChannelRobotSdk.Response;
using QqChannelRobotSdk.Sdk;
using QqChannelRobotSdk.WebSocket;
using QqChannelRobotSdk.WebSocket.Models;

namespace QqChannelRobotSdk;

public class Program
{
    static void Main(string[] args)
    {
        BotIdentifier identifier = new BotIdentifier("102015437", "kaCdppjaJtFQOBj6", "vLeMjyFXdcgNEVWMJlEVKAfFhAfi2h4W");
        QqGuildWebSocketListener listener = new QqGuildWebSocketListener(identifier);
        listener.RegisteredEvent = PrimaryEventType.Guilds | PrimaryEventType.GuildMembers | PrimaryEventType.GuildMessages | PrimaryEventType.PublicGildMessages;
        listener.Start();
        
        while (true)
        {
            Thread.Sleep(1);
        }

    }
}