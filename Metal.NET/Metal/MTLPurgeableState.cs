namespace Metal.NET;

public enum MTLPurgeableState : ulong
{
    MTLPurgeableStateKeepCurrent = 1,
    MTLPurgeableStateNonVolatile = 2,
    MTLPurgeableStateVolatile = 3,
    MTLPurgeableStateEmpty = 4
}
