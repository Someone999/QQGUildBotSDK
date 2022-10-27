using System.Collections;
using QqGuildRobotSdk.WebSocket.PacketHandlers.Server;

namespace QqGuildRobotSdk.Tools;

public class ReflectionTypeCollection : IEnumerable<Type>
{
    private List<Type> _types = new List<Type>();
    public Type[] Types => _types.ToArray();
    public ReflectionTypeCollection(IEnumerable<Type> types)
    {
        _types.AddRange(types);
    }

    public ReflectionTypeCollection GetSubTypesOf(Type t)
    {
        List<Type> types = new List<Type>();
        foreach (var type in _types)
        {
            if (type == typeof(HelloPacketHandler))
            {
                ;
            }
            if (!type.IsAssignableTo(t) || type.IsInterface || type.IsAbstract)
            {
                continue;
            }
            
            types.Add(type);
        }

        return new ReflectionTypeCollection(types);
    }

    public ReflectionTypeCollection GetSubTypesOf<T>() => GetSubTypesOf(typeof(T));
    public IEnumerator<Type> GetEnumerator()
    {
        return _types.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}