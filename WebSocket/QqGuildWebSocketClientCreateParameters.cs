using QqGuildRobotSdk.Authenticate;
using QqGuildRobotSdk.Tools;
using QqGuildRobotSdk.WebSocket.Models;

namespace QqGuildRobotSdk.WebSocket;

public class QqGuildWebSocketClientCreateParameters
{
    public QqGuildWebSocketClientCreateParameters(BotIdentifier identifier)
    {
        Identifier = identifier;
    }
    public BotIdentifier Identifier { get; set; }
    private int? _maxShardCount;

    /// <summary>
    /// 如果没有指定MaxShardCount，则会使用从服务器获取建议值
    /// If MaxShardCount is not specified, a recommended value gets from the server will be used.
    /// </summary>
    public int? MaxShardCount
    {
        get
        {
            if (_maxShardCount != null)
            {
                return _maxShardCount;
            }

            var httpClient = Identifier.GetBotTokenAuthenticateHttpClient();
            var baseUrl = "https://api.sgroup.qq.com/gateway/bot";
            var response = httpClient.GetAsync(baseUrl).Result;
            var data = 
                ResponseTools.GetReturnValueAsync<MultiShardWebSocketConnectionInfo>(response).Result;
            var responseData = data.ResponseObject;
            return _maxShardCount = responseData?.RecommendedShards ?? 0;
        }
        set => _maxShardCount = value;
    }

    private string? _wssUrl;

    public string WssUrl
    {
        get
        {
            if (_wssUrl != null)
            {
                return _wssUrl;
            }

            bool isMultiShard = MaxShardCount > 1;
            
            string url = isMultiShard
                ? "https://api.sgroup.qq.com/gateway/bot"
                : "https://api.sgroup.qq.com/gateway";
            var httpClient = Identifier.GetBotTokenAuthenticateHttpClient();
            var response = httpClient.GetAsync(url).Result;
            var data = 
                ResponseTools.GetReturnValueAsync<WebSocketConnectionInfo>(response).Result;
            
            var responseData = data.ResponseObject;
            return _wssUrl = responseData?.Url ?? "";
        }
    }
    public PrimaryEventType RegisteredEvents { get; set; }
    public bool AutoStart { get; set; }
}