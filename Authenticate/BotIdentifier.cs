using Newtonsoft.Json;

namespace QqChannelRobotSdk.Authenticate;

public class BotIdentifier : IEqualityComparer<BotIdentifier>
{
    [JsonProperty("bot_app_id")]
    public string BotAppId { get; set; } = "";
    
    [JsonProperty("bot_secret")]
    public string BotSecretKey { get; set; } = "";
    
    [JsonProperty("bot_token")]
    public string BotToken { get; set; } = "";

    static HttpClient _botTokenAuthenticateHttpClient;
    public BotIdentifier(string botAppId, string botSecretKey, string botToken)
    {
        BotAppId = botAppId;
        BotSecretKey = botSecretKey;
        BotToken = botToken;
        string concatToken = "Bot " + BotAppId + "." + BotToken;
        BotAuthToken = concatToken;
        _botTokenAuthenticateHttpClient = new HttpClient();
        _botTokenAuthenticateHttpClient.DefaultRequestHeaders.Add("Authorization", concatToken);
        
    }

    public HttpClient GetBotTokenAuthenticateHttpClient()
    {
        return _botTokenAuthenticateHttpClient;
    }
    
    public bool Equals(BotIdentifier? x, BotIdentifier? y)
    {
        if (ReferenceEquals(x, y))
            return true;
        if (ReferenceEquals(x, null))
            return false;
        if (ReferenceEquals(y, null))
            return false;
        if (x.GetType() != y.GetType())
            return false;
        return x.BotAppId == y.BotAppId && x.BotSecretKey == y.BotSecretKey && x.BotToken == y.BotToken;
    }
    public int GetHashCode(BotIdentifier obj)
    {
        return HashCode.Combine(obj.BotAppId, obj.BotSecretKey, obj.BotToken);
    }
    
    public string BotAuthToken { get; } 
}