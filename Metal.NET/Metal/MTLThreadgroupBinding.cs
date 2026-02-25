namespace Metal.NET;

public class MTLThreadgroupBinding(nint nativePtr, bool ownsReference = true) : MTLBinding(nativePtr, ownsReference), INativeObject<MTLThreadgroupBinding>
{
    public static new MTLThreadgroupBinding Create(nint nativePtr) => new(nativePtr);

    public static new MTLThreadgroupBinding CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

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
