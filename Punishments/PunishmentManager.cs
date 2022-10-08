using System.Reflection;
using QqChannelRobotSdk.Tools;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public static class PunishmentManager
{
    private static Dictionary<Type, IPunishment> _punishments = new();
    private static bool _initialized;

    public static IPunishment[] Punishments
    {
        get
        {
            Init();
            return _punishments.Values.ToArray();
        }
    }
    static void Init()
    {
        if (_initialized)
        {
            return;
        }
        
        lock (_punishments)
        {
            _initialized = true;
            var punishmentTypes =
                ReflectionAssemblyManager.GetAssembliesTypes().GetSubTypesOf<IPunishment>();
            foreach (var punishmentType in punishmentTypes)
            {
                ConstructorInfo? constructorInfo = punishmentType.GetConstructor(Type.EmptyTypes);
                IPunishment? ins = (IPunishment?)constructorInfo?.Invoke(Array.Empty<object>());
                if (ins == null)
                {
                    continue;
                }
           
                _punishments.Add(punishmentType, ins);
            }
        }
        
    }

    public static IPunishment? GetPunishment(Type t)
    {
        Init();

        return _punishments.ContainsKey(t)
            ? _punishments[t]
            : null;
    }

    public static T? GetPunishment<T>() where T: IPunishment
    {
        return (T?) GetPunishment(typeof(T));
    }
}