using HsManCommonLibrary.NestedValues.Attributes;

namespace QqGuildRobotSdk.Configs;

public class MainConfig
{
    [AutoAssign("bot.appId")]
    public string BotAppId { get; internal set; } = "";
    
    [AutoAssign("bot.token")]
    public string BotToken { get; internal set; } = "";
    
    [AutoAssign("bot.secret")]
    public string BotSecret { get; internal set; } = "";
}