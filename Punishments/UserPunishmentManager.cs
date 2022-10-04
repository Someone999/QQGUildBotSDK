using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public class UserPunishmentManager
{
    private UserPunishmentManager()
    {
    }
    private void HandlePunishResult(IPunishment punishment, PunishmentExecutionResult result, User user)
    {
        switch (result)
        {
            case PunishmentExecutionResult.ResetCounter:
                _userPunishments[user].AppliedPunishment.Clear();
                break;
            case PunishmentExecutionResult.RemoveId:
                _userPunishments.Remove(user);
                break;
            case PunishmentExecutionResult.Unhandled:
            case PunishmentExecutionResult.Failed:
            case PunishmentExecutionResult.NoHandler:
            case PunishmentExecutionResult.Handled:
            default:
                break;
        }
    }
    
    private Dictionary<User, UserPunishmentInfo> _userPunishments= new();

    public PunishmentExecutionResult Punish(IPunishment punishment, MessageCreateEventArgs eventArgs)
    {
        var user = eventArgs.Message.Author;
        UserPunishmentInfo? punishmentInfo;
        if (!_userPunishments.ContainsKey(user))
        {
            _userPunishments.Add(user, punishmentInfo = new UserPunishmentInfo(user));
        }
        else
        {
            punishmentInfo = _userPunishments[user];
        }

        int violationCount = punishmentInfo.AppliedPunishment.Count;
        var rslt = punishmentInfo.ApplyPunishment(punishment, eventArgs, violationCount);
        HandlePunishResult(punishment, rslt, user);
        return rslt;
    }
    
    
    public PunishmentExecutionResult Punish<T>(MessageCreateEventArgs eventArgs) where T: IPunishment
    {
        var user = eventArgs.Message.Author;
        UserPunishmentInfo? punishmentInfo;
        if (!_userPunishments.ContainsKey(user))
        {
            _userPunishments.Add(user, punishmentInfo = new UserPunishmentInfo(user));
        }
        else
        {
            punishmentInfo = _userPunishments[user];
        }
        var punishment = PunishManager.GetPunishment<T>();
        if (punishment == null)
        {
            return PunishmentExecutionResult.NoHandler;
        }
        
        int violationCount = punishmentInfo.AppliedPunishment.Count;
        var rslt = punishmentInfo.ApplyPunishment(punishment, eventArgs, violationCount);
        HandlePunishResult(punishment, rslt, user);
        return rslt;
    }

    private static readonly object StaticLocker = new object();
    private static UserPunishmentManager? _instance;

    public static UserPunishmentManager GetInstance()
    {
        if (_instance != null)
        {
            return _instance;
        }
        
        lock (StaticLocker)
        {
            _instance ??= new UserPunishmentManager();
            return _instance;
        }
    }

}