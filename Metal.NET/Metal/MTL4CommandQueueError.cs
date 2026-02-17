namespace Metal.NET;

public enum MTL4CommandQueueError : int
{
    CommandQueueErrorNone = 0,

    CommandQueueErrorTimeout = 1,

    CommandQueueErrorNotPermitted = 2,

    CommandQueueErrorOutOfMemory = 3,

    CommandQueueErrorDeviceRemoved = 4,

    CommandQueueErrorAccessRevoked = 5,

    CommandQueueErrorInternal = 6
}
