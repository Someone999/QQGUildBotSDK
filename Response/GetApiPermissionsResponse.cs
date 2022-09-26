using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QqChannelRobotSdk.Models;

namespace QqChannelRobotSdk.Response
{
    public class GetApiPermissionsResponse
    {
        [JsonProperty("apis")]
        public ApiPermission[] ApiPermissions { get; private set; } = Array.Empty<ApiPermission>();
    }
}
