namespace Metal.NET;

[Flags]
public enum MTLResourceOptions : ulong
{
    MTLResourceCPUCacheModeDefaultCache = 0,

    MTLResourceCPUCacheModeWriteCombined = 1,

    MTLResourceStorageModeShared = 0,

    MTLResourceStorageModeManaged = 16,

    MTLResourceStorageModePrivate = 32,

    MTLResourceStorageModeMemoryless = 32,

    MTLResourceHazardTrackingModeDefault = 0,

    MTLResourceHazardTrackingModeUntracked = 256,

    MTLResourceHazardTrackingModeTracked = 512,

    MTLResourceOptionCPUCacheModeDefault = 0,

    MTLResourceOptionCPUCacheModeWriteCombined = 1
}
