using Newtonsoft.Json;
using QqGuildRobotSdk.Models;

namespace QqGuildRobotSdk.Response
{
    public class GetApiPermissionsResponse
    {
        [JsonProperty("apis")]
        public ApiPermission[] ApiPermissions { get; private set; } = Array.Empty<ApiPermission>();
    }
}
