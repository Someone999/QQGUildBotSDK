using System.Reflection;

namespace QqChannelRobotSdk.Tools;

public static class ReflectionAssemblyManager
{
    private static List<Assembly> _registeredAssemblies = new List<Assembly>();
    public static Assembly[] RegisteredAssemblies => _registeredAssemblies.ToArray();
    public static void Add(Assembly asm)
    {
        if (_registeredAssemblies.Contains(asm))
        {
            return;
        }
        
        _registeredAssemblies.Add(asm);
    }

    public static void Remove(Assembly asm) => _registeredAssemblies.Remove(asm);
    public static ReflectionTypeCollection GetAssembliesTypes()
    {
        List<Type> types = new List<Type>();
        var assembliesTypes = from asm in _registeredAssemblies select asm.GetTypes();
        foreach (var assemblyTypes in assembliesTypes)
        {
            types.AddRange(assemblyTypes);
        }

        return new ReflectionTypeCollection(types);
    }
}