﻿namespace QqChannelRobotSdk.Models;

[Flags]
public enum ChannelPermission
{
    None = 0,
    Access = 1,
    Manage = 2,
    Speak = 4,
    Live = 8
}