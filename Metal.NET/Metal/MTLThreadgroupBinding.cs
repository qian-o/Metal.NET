namespace Metal.NET;

public class MTLThreadgroupBinding(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLBinding(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLThreadgroupBinding>
{
    public static new MTLThreadgroupBinding Null { get; } = new(0, false, false);

    public static new MTLThreadgroupBinding Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public nuint ThreadgroupMemoryAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLThreadgroupBindingBindings.ThreadgroupMemoryAlignment);
    }

    public nuint ThreadgroupMemoryDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLThreadgroupBindingBindings.ThreadgroupMemoryDataSize);
    }
}

file static class MTLThreadgroupBindingBindings
{
    public static readonly Selector ThreadgroupMemoryAlignment = "threadgroupMemoryAlignment";

    public static readonly Selector ThreadgroupMemoryDataSize = "threadgroupMemoryDataSize";
}
