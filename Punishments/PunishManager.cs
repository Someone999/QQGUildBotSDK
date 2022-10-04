using System.Reflection;
using QqChannelRobotSdk.Tools;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public static class PunishManager
{
    private static Dictionary<Type, IPunishment> _punishments = new();
    private static bool _initialized = false;
    static void Init()
    {
        if (_initialized)
        {
            return;
        }
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
    
    public static PunishmentExecutionResult Punish(MessageCreateEventArgs eventArgs)
    {
        Init();
        
        foreach (var punishment in _punishments.Values)
        {
            var rslt = UserPunishmentManager.GetInstance().Punish(punishment, eventArgs);
            switch (rslt)   
            {
                case PunishmentExecutionResult.Handled:
                case PunishmentExecutionResult.ResetCounter:
                case PunishmentExecutionResult.RemoveId:
                    return rslt;
                case PunishmentExecutionResult.Failed:
                case PunishmentExecutionResult.Unhandled:
                default:
                    continue;
            }
            
        }
        return PunishmentExecutionResult.NoHandler;
    }
}