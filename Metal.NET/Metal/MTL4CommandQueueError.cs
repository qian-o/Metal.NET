namespace Metal.NET;

public enum MTL4CommandQueueError : long
{
    MTL4CommandQueueErrorNone = 0,

    MTL4CommandQueueErrorTimeout = 1,

    MTL4CommandQueueErrorNotPermitted = 2,

    MTL4CommandQueueErrorOutOfMemory = 3,

    MTL4CommandQueueErrorDeviceRemoved = 4,

    MTL4CommandQueueErrorAccessRevoked = 5,

    MTL4CommandQueueErrorInternal = 6
}
