namespace QqChannelRobotSdk.Models.Forums;

public class RichObjectAtInfo
{
    public RichObjectAtType AtType { get; private set; }

    public ForumAtUserInfo ForumAtUserInfo { get; private set; } = ForumAtUserInfo.Empty;

    public ForumAtRoleInfo ForumAtRoleInfo { get; private set; } = ForumAtRoleInfo.Empty;
    public ForumAtGuildInfo ForumAtGuildInfo { get; private set; } = ForumAtGuildInfo.Empty;

}