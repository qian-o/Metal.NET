namespace Metal.NET;

public enum MTL4CommandQueueError : long
{
    None = 0,

    Timeout = 1,

    NotPermitted = 2,

    OutOfMemory = 3,

    DeviceRemoved = 4,

    AccessRevoked = 5,

    Internal = 6
}
