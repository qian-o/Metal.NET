namespace Metal.NET;

public enum MTLCounterSamplingPoint : ulong
{
    MTLCounterSamplingPointAtStageBoundary = 0,

    MTLCounterSamplingPointAtDrawBoundary = 1,

    MTLCounterSamplingPointAtDispatchBoundary = 2,

    MTLCounterSamplingPointAtTileDispatchBoundary = 3,

    MTLCounterSamplingPointAtBlitBoundary = 4
}
