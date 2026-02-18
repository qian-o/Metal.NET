namespace Metal.NET;

[Flags]
public enum MTLAccelerationStructureUsage : ulong
{
    MTLAccelerationStructureUsageNone = 0,

    MTLAccelerationStructureUsageRefit = 1,

    MTLAccelerationStructureUsagePreferFastBuild = 2,

    MTLAccelerationStructureUsageExtendedLimits = 4,

    MTLAccelerationStructureUsagePreferFastIntersection = 16,

    MTLAccelerationStructureUsageMinimizeMemory = 32
}
