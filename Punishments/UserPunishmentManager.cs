﻿using System.Collections.ObjectModel;
using QqChannelRobotSdk.Models;
using QqChannelRobotSdk.Tools;
using QqChannelRobotSdk.WebSocket.Events.EventArgs;

namespace QqChannelRobotSdk.Punishments;

public class UserPunishmentManager
{
    private UserPunishmentManager()
    {
    }

    public IPunishResultHandler PunishResultHandler { get; set; } = new DefaultPunishResultHandler();
    
    public Dictionary<User, UserPunishmentInfo> UserPunishments { get; } = new();

    public PunishmentExecutionResult Punish(PunishmentParameters parameters)
    {
        var user = parameters.EventArgs.Message.Author;
        UserPunishmentInfo? punishmentInfo;
        if (!UserPunishments.ContainsKey(user))
        {
            UserPunishments.Add(user, punishmentInfo = new UserPunishmentInfo(user));
        }
        else
        {
            punishmentInfo = UserPunishments[user];
        }

        int violationCount = punishmentInfo.AppliedPunishment.Count;
        var rslt = punishmentInfo.ApplyPunishment(parameters);
        PunishResultHandler.Handle(parameters.Punishment, rslt, parameters.EventArgs);
        return rslt;
    }
    
    
    public PunishmentExecutionResult Punish<T>(PunishmentParameters parameters) where T: IPunishment
    {
        var user = parameters.EventArgs.Message.Author;
        UserPunishmentInfo? punishmentInfo;
        if (!UserPunishments.ContainsKey(user))
        {
            UserPunishments.Add(user, punishmentInfo = new UserPunishmentInfo(user));
        }
        else
        {
            punishmentInfo = UserPunishments[user];
        }
        var punishment = PunishmentManager.GetPunishment<T>();
        if (punishment == null)
        {
            return PunishmentExecutionResult.NoHandler;
        }
        
        parameters.ViolationCount = parameters.ViolationCount == -1 ? punishmentInfo.AppliedPunishment.Count : parameters.ViolationCount;
        parameters.Punishment = punishment;
        var rslt = punishmentInfo.ApplyPunishment(parameters);
        PunishResultHandler.Handle(punishment, rslt, parameters.EventArgs);
        return rslt;
    }

    public PunishmentExecutionResult AutoPunish(PunishmentParameters parameters)
    {
        var user = parameters.EventArgs.Message.Author;
        UserPunishmentInfo? punishmentInfo;
        if (!UserPunishments.ContainsKey(user))
        {
            UserPunishments.Add(user, punishmentInfo = new UserPunishmentInfo(user));
        }
        else
        {
            punishmentInfo = UserPunishments[user];
        }

        parameters.ViolationCount = parameters.ViolationCount == -1 ? punishmentInfo.AppliedPunishment.Count : parameters.ViolationCount;
        
        var punishments =
            from p in PunishmentManager.Punishments
            where MathUtils.InRange(parameters.ViolationCount, p.MinViolationCount, p.MaxViolationCount)
            orderby p.Priority descending select p;

        IPunishment? punishment = punishments.FirstOrDefault();
        var rslt = punishment?.Punish(parameters) ?? PunishmentExecutionResult.NoHandler;
        if (punishment == null)
        {
            return PunishmentExecutionResult.NoHandler;
        }
        
        PunishResultHandler.Handle(punishment, rslt, parameters.EventArgs);
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