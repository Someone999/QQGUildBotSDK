using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.Models.Members;

namespace QqChannelRobotSdk.WebSocket.Models
{
    public class WebSocketMember : MemberWithGuildId
    {
        [JsonProperty("op_user_id")] public string OperatorId { get; set; } = "";
    }
}
