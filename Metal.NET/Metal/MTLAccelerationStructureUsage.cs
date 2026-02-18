namespace Metal.NET;

[Flags]
public enum MTLAccelerationStructureUsage : ulong
{
    AccelerationStructureUsageNone = 0,

    AccelerationStructureUsageRefit = 1,

    AccelerationStructureUsagePreferFastBuild = 2,

    AccelerationStructureUsageExtendedLimits = 4,

    AccelerationStructureUsagePreferFastIntersection = 16,

    AccelerationStructureUsageMinimizeMemory = 32
}
