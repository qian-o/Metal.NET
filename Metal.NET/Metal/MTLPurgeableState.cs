namespace Metal.NET;

public enum MTLPurgeableState : ulong
{
    PurgeableStateKeepCurrent = 1,

    PurgeableStateNonVolatile = 2,

    PurgeableStateVolatile = 3,

    PurgeableStateEmpty = 4
}
