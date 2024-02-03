namespace QqGuildRobotSdk.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class InternalUseOnlyAttribute : Attribute
{
    private readonly string? _description;

    public InternalUseOnlyAttribute()
    {
    }
    public InternalUseOnlyAttribute(string description)
    {
        _description = description;
    }
}