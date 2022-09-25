namespace QqChannelRobotSdk.Tools;

public static class ParameterChecker
{
    public static bool InValues<T>(T value, params T[] values) => values.Contains(value);
}