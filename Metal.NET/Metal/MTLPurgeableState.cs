namespace Metal.NET;

public enum MTLPurgeableState : uint
{
    PurgeableStateKeepCurrent = 1,

    PurgeableStateNonVolatile = 2,

    PurgeableStateVolatile = 3,

    PurgeableStateEmpty = 4
}
