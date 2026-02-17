namespace Metal.NET;

public enum MTLCommandBufferError : uint
{
    None = 0,

    Internal = 1,

    Timeout = 2,

    PageFault = 3,

    Blacklisted = 4,

    AccessRevoked = 4,

    NotPermitted = 7,

    OutOfMemory = 8,

    InvalidResource = 9,

    Memoryless = 10,

    DeviceRemoved = 11,

    StackOverflow = 12
}
