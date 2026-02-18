namespace Metal.NET;

[Flags]
public enum NSActivityOptions : ulong
{
    ActivityIdleDisplaySleepDisabled = 1099511627776,

    ActivityIdleSystemSleepDisabled = 1048576,

    ActivitySuddenTerminationDisabled = 16384,

    ActivityAutomaticTerminationDisabled = 32768,

    ActivityUserInitiated = 0x00FFFFFF | ActivityIdleSystemSleepDisabled,

    ActivityUserInitiatedAllowingIdleSystemSleep = ActivityUserInitiated & ~ActivityIdleSystemSleepDisabled,

    ActivityBackground = 255,

    ActivityLatencyCritical = 1095216660480
}
