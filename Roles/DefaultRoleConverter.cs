using QqGuildRobotSdk.Models;

namespace QqGuildRobotSdk.Roles;

public class DefaultRoleConverter : IRoleConverter
{
    public DefaultRoles Convert(string role, string roleId)
    {
        return (DefaultRoles)int.Parse(roleId);
    }
}