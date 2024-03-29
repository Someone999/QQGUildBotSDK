﻿using System.Reflection;
using QqGuildRobotSdk.Tools;
using QqGuildRobotSdk.WebSocket.Packets;

namespace QqGuildRobotSdk.WebSocket.PacketHandlers;

public static class PacketHandlerManager
{
    private static bool _initialized;
    private static Dictionary<(OperationCode, string?), IPacketHandler> _packetHandlers = new();

    private static void Init()
    {
        if (!ReflectionAssemblyManager.RegisteredAssemblies.Contains(typeof(PacketManager).Assembly))
        {
            ReflectionAssemblyManager.Add(typeof(PacketManager).Assembly);
        }

        var subTypes = ReflectionAssemblyManager.GetAssembliesTypes().GetSubTypesOf<IPacketHandler>();
        foreach (var subType in subTypes)
        {
            ConstructorInfo? constructorInfo = subType.GetConstructor(Type.EmptyTypes);
            IPacketHandler? packetHandler = (IPacketHandler?) constructorInfo?.Invoke(Array.Empty<object>());
            if (packetHandler == null)
            {
                continue;
            }

            _packetHandlers.Add((packetHandler.Code, packetHandler.SubEventType), packetHandler);
        }
        _initialized = true;
    }

    public static IPacketHandler? GetHandler(OperationCode opCode, string? subType)
    {
        lock (typeof(PacketHandlerManager))
        {
            if (!_initialized)
            {
                Init();
            }
        }
        return _packetHandlers.ContainsKey((opCode, subType))
            ? _packetHandlers[(opCode, subType)]
            : null;
    }

    public static T? GetHandler<T>(OperationCode opCode, string? subType) => (T?)GetHandler(opCode, subType);

}