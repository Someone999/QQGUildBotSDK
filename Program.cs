using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using QqChannelRobotSdk.Authenticate;
using QqChannelRobotSdk.Messages;
using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.Punishments;
using QqChannelRobotSdk.Request;
using QqChannelRobotSdk.Response;
using QqChannelRobotSdk.Sdk;
using QqChannelRobotSdk.Tools;
using QqChannelRobotSdk.WebSocket;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets.ServerPackets;

namespace QqChannelRobotSdk;


public static class ModuleInitializer
{
    [ModuleInitializer]
    internal static void Init()
    {
        ReflectionAssemblyManager.Add(typeof(ModuleInitializer).Assembly);
    }
}
public class Program
{
    static void Main(string[] args)
    {
    }
}