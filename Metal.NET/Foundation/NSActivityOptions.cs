namespace Metal.NET;

[Flags]
public enum NSActivityOptions : ulong
{
    ActivityIdleDisplaySleepDisabled = 1ULL << 40,

    ActivityIdleSystemSleepDisabled = 1ULL << 20,

    ActivitySuddenTerminationDisabled = 1ULL << 14,

    ActivityAutomaticTerminationDisabled = 1ULL << 15,

    ActivityUserInitiated = 0x00FFFFFFULL | ActivityIdleSystemSleepDisabled,

    ActivityUserInitiatedAllowingIdleSystemSleep = ActivityUserInitiated & ~ActivityIdleSystemSleepDisabled,

    ActivityBackground = 255,

    ActivityLatencyCritical = 1095216660480
}
