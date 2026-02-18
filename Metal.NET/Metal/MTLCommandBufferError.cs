namespace Metal.NET;

public enum MTLCommandBufferError : ulong
{
    CommandBufferErrorNone = 0,

    CommandBufferErrorInternal = 1,

    CommandBufferErrorTimeout = 2,

    CommandBufferErrorPageFault = 3,

    CommandBufferErrorBlacklisted = 4,

    CommandBufferErrorAccessRevoked = 4,

    CommandBufferErrorNotPermitted = 7,

    CommandBufferErrorOutOfMemory = 8,

    CommandBufferErrorInvalidResource = 9,

    CommandBufferErrorMemoryless = 10,

    CommandBufferErrorDeviceRemoved = 11,

    CommandBufferErrorStackOverflow = 12
}
