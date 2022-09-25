using QqChannelRobotSdk.Authenticate;

namespace QqChannelRobotSdk.Sdk;

class QqChannelBotSdkManager
{
    private QqChannelBotSdkManager()
    {
    }

    private static readonly object StaticLocker = new object();
    private static QqChannelBotSdkManager? _instance;

    public static QqChannelBotSdkManager GetInstance()
    {
        if (_instance != null)
        {
            return _instance;
        }

        lock (StaticLocker)
        {
            _instance ??= new QqChannelBotSdkManager();
        }

        return _instance;
    }

    private Dictionary<BotIdentifier, QqGuildBotSdk> _sdks = new Dictionary<BotIdentifier, QqGuildBotSdk>();
    internal void Add(QqGuildBotSdk sdk)
    {
        if (_sdks.ContainsKey(sdk.BotIdentifier))
        {
            return;
        }
        
        _sdks.Add(sdk.BotIdentifier, sdk);
    }

    public bool Remove(QqGuildBotSdk sdk) => _sdks.Remove(sdk.BotIdentifier);
    public QqGuildBotSdk Get(BotIdentifier identifier)
    {
        if (_sdks.ContainsKey(identifier))
        {
            return _sdks[identifier];
        }
        var newSdk = new QqGuildBotSdk(identifier);
        Add(newSdk);
        return newSdk;

    }
}