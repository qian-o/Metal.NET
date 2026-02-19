namespace Metal.NET;

[Flags]
public enum MTLResourceOptions : ulong
{
    ResourceCPUCacheModeDefaultCache = 0,

    ResourceCPUCacheModeWriteCombined = 1,

    ResourceStorageModeShared = 0,

    ResourceStorageModeManaged = 16,

    ResourceStorageModePrivate = 32,

    ResourceStorageModeMemoryless = 32,

    ResourceHazardTrackingModeDefault = 0,

    ResourceHazardTrackingModeUntracked = 256,

    ResourceHazardTrackingModeTracked = 512,

    ResourceOptionCPUCacheModeDefault = 0,

    ResourceOptionCPUCacheModeWriteCombined = 1
}
