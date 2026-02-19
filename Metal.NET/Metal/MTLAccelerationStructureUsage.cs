namespace Metal.NET;

[Flags]
public enum MTLAccelerationStructureUsage : ulong
{
    None = 0,

    Refit = 1,

    PreferFastBuild = 2,

    ExtendedLimits = 4,

    PreferFastIntersection = 16,

    MinimizeMemory = 32
}
