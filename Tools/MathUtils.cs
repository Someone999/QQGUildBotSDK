namespace QqChannelRobotSdk.Tools;

public static class MathUtils
{
    public static bool InRange(double number, double min, double max)
    {
        return number <= max && number >= min;
    }

}