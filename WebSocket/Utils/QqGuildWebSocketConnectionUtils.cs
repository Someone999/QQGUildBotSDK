using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QqGuildRobotSdk.Authenticate;
using QqGuildRobotSdk.Response;
using QqGuildRobotSdk.WebSocket.Models;

namespace QqGuildRobotSdk.WebSocket.Utils;

public class QqGuildWssUrlRequest
{
    public QqGuildWssUrlRequest(BotIdentifier botIdentifier)
    {
        BotIdentifier = botIdentifier;
    }

    public bool UseSandboxEnvironment { get; set; }
    public BotIdentifier BotIdentifier { get; set; }
}

public static class QqGuildWebSocketConnectionUtils
{
    public static async Task<ApiResponse<WebSocketConnectionInfo, GeneralErrorResponse>> 
        GetConnectionUrl(QqGuildWssUrlRequest request)
    {
        var sandBoxBaseUrl = "https://sandbox.api.sgroup.qq.com/gateway";
        var baseUrl = "https://api.sgroup.qq.com/gateway";
        var realUrl = request.UseSandboxEnvironment ? sandBoxBaseUrl : baseUrl;
        var c = request.BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var res = await c.GetAsync(realUrl);
        var json = await res.Content.ReadAsStringAsync();
        var jToken = JsonConvert.DeserializeObject<JToken>(json);
        if (jToken == null)
        {
            throw new Exception();
        }
        var code = jToken["code"];
        if (code != null)
        {
            return new ApiResponse<WebSocketConnectionInfo, GeneralErrorResponse>
                (null, GeneralErrorResponse.Create(jToken, res));
        }
       
        
        ApiResponse<WebSocketConnectionInfo, GeneralErrorResponse> response =
            new ApiResponse<WebSocketConnectionInfo, GeneralErrorResponse>
                (jToken.ToObject<WebSocketConnectionInfo>(), null);

        return response;
    }
    
    public static async Task<ApiResponse<MultiShardWebSocketConnectionInfo, GeneralErrorResponse>> 
        GetMultiShardConnectionUrl(QqGuildWssUrlRequest request)
    {
        var sandBoxBaseUrl = "https://sandbox.api.sgroup.qq.com/gateway/bot";
        var baseUrl = "https://api.sgroup.qq.com/gateway/bot";
        var realUrl = request.UseSandboxEnvironment ? sandBoxBaseUrl : baseUrl;
        var c = request.BotIdentifier.GetBotTokenAuthenticateHttpClient();
        var res = await c.GetAsync(realUrl);
        var json = await res.Content.ReadAsStringAsync();
        var jToken = JsonConvert.DeserializeObject<JToken>(json);
        if (jToken == null)
        {
            throw new Exception();
        }
        var code = jToken["code"];
        if (code != null)
        {
            return new ApiResponse<MultiShardWebSocketConnectionInfo, GeneralErrorResponse>
                (null, GeneralErrorResponse.Create(jToken, res));
        }
       
        
        ApiResponse<MultiShardWebSocketConnectionInfo, GeneralErrorResponse> response =
            new ApiResponse<MultiShardWebSocketConnectionInfo, GeneralErrorResponse>
                (jToken.ToObject<MultiShardWebSocketConnectionInfo>(), null);

        return response;
    }
}