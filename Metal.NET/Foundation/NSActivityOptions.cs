namespace Metal.NET;

[Flags]
public enum NSActivityOptions : ulong
{
    NSActivityIdleDisplaySleepDisabled = 1099511627776,
    NSActivityIdleSystemSleepDisabled = 1048576,
    NSActivitySuddenTerminationDisabled = 16384,
    NSActivityAutomaticTerminationDisabled = 32768,
    NSActivityUserInitiated = 16777215,
    NSActivityUserInitiatedAllowingIdleSystemSleep = 15728639,
    NSActivityBackground = 255,
    NSActivityLatencyCritical = 1095216660480
}
