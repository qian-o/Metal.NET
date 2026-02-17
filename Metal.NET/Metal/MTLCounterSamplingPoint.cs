namespace Metal.NET;

public enum MTLCounterSamplingPoint : uint
{
    CounterSamplingPointAtStageBoundary = 0,

    CounterSamplingPointAtDrawBoundary = 1,

    CounterSamplingPointAtDispatchBoundary = 2,

    CounterSamplingPointAtTileDispatchBoundary = 3,

    CounterSamplingPointAtBlitBoundary = 4
}
