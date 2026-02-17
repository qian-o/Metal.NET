namespace Metal.NET;

public enum MTLCommandBufferStatus : uint
{
    CommandBufferStatusNotEnqueued = 0,

    CommandBufferStatusEnqueued = 1,

    CommandBufferStatusCommitted = 2,

    CommandBufferStatusScheduled = 3,

    CommandBufferStatusCompleted = 4,

    CommandBufferStatusError = 5
}
