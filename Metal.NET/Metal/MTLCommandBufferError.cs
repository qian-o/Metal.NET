namespace Metal.NET;

public enum MTLCommandBufferError : ulong
{
    MTLCommandBufferErrorNone = 0,

    MTLCommandBufferErrorInternal = 1,

    MTLCommandBufferErrorTimeout = 2,

    MTLCommandBufferErrorPageFault = 3,

    MTLCommandBufferErrorBlacklisted = 4,

    MTLCommandBufferErrorAccessRevoked = 4,

    MTLCommandBufferErrorNotPermitted = 7,

    MTLCommandBufferErrorOutOfMemory = 8,

    MTLCommandBufferErrorInvalidResource = 9,

    MTLCommandBufferErrorMemoryless = 10,

    MTLCommandBufferErrorDeviceRemoved = 11,

    MTLCommandBufferErrorStackOverflow = 12
}
