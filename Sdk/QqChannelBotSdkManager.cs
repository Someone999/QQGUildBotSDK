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

    private Dictionary<BotIdentifier, QqChannelBotSdk> _sdks = new Dictionary<BotIdentifier, QqChannelBotSdk>();
    internal void Add(QqChannelBotSdk sdk)
    {
        if (_sdks.ContainsKey(sdk.BotIdentifier))
        {
            return;
        }
        
        _sdks.Add(sdk.BotIdentifier, sdk);
    }

    public bool Remove(QqChannelBotSdk sdk) => _sdks.Remove(sdk.BotIdentifier);
    public QqChannelBotSdk Get(BotIdentifier identifier)
    {
        if (_sdks.ContainsKey(identifier))
        {
            return _sdks[identifier];
        }
        var newSdk = new QqChannelBotSdk(identifier);
        Add(newSdk);
        return newSdk;

    }
}