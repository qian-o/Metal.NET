namespace Metal.NET;

[Flags]
public enum NSActivityOptions : ulong
{
    IdleDisplaySleepDisabled = 1099511627776,

    IdleSystemSleepDisabled = 1048576,

    SuddenTerminationDisabled = 16384,

    AutomaticTerminationDisabled = 32768,

    UserInitiated = 16777215,

    UserInitiatedAllowingIdleSystemSleep = 15728639,

    Background = 255,

    LatencyCritical = 1095216660480
}
