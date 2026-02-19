namespace Metal.NET;

[Flags]
public enum MTLResourceOptions : ulong
{
    CPUCacheModeDefaultCache = 0,

    CPUCacheModeWriteCombined = 1,

    StorageModeShared = 0,

    StorageModeManaged = 16,

    StorageModePrivate = 32,

    StorageModeMemoryless = 32,

    HazardTrackingModeDefault = 0,

    HazardTrackingModeUntracked = 256,

    HazardTrackingModeTracked = 512,

    OptionCPUCacheModeDefault = 0,

    OptionCPUCacheModeWriteCombined = 1
}
