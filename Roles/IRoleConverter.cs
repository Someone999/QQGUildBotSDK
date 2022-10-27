using QqGuildRobotSdk.Models;

namespace QqGuildRobotSdk.Roles;

public interface IRoleConverter
{
    public DefaultRoles Convert(string role, string roleId);
}