namespace QqGuildRobotSdk.Attributes;


[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class NotImplementedAttribute : Attribute
{
    private readonly string _description;

    public NotImplementedAttribute(string description)
    {
        _description = description;
    }
}