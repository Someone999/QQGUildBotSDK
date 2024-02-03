namespace QqGuildRobotSdk.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class WorkInProgressAttribute : Attribute
{
    private readonly string _description;

    public WorkInProgressAttribute(string description)
    {
        _description = description;
    }
}