namespace Metal.NET;

public partial class MTLThreadgroupBinding : NativeObject
{
    public MTLThreadgroupBinding(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint ThreadgroupMemoryAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLThreadgroupBindingSelector.ThreadgroupMemoryAlignment);
    }

    public nuint ThreadgroupMemoryDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLThreadgroupBindingSelector.ThreadgroupMemoryDataSize);
    }
}

file static class MTLThreadgroupBindingSelector
{
    public static readonly Selector ThreadgroupMemoryAlignment = Selector.Register("threadgroupMemoryAlignment");

    public static readonly Selector ThreadgroupMemoryDataSize = Selector.Register("threadgroupMemoryDataSize");
}
