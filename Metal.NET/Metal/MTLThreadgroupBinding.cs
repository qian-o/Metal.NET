namespace Metal.NET;

public class MTLThreadgroupBinding(nint nativePtr) : MTLBinding(nativePtr)
{
    public nuint ThreadgroupMemoryAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLThreadgroupBindingSelector.ThreadgroupMemoryAlignment);
    }

    public nuint ThreadgroupMemoryDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLThreadgroupBindingSelector.ThreadgroupMemoryDataSize);
    }

    public static implicit operator nint(MTLThreadgroupBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLThreadgroupBinding(nint value)
    {
        return new(value);
    }
}

file class MTLThreadgroupBindingSelector
{
    public static readonly Selector ThreadgroupMemoryAlignment = Selector.Register("threadgroupMemoryAlignment");

    public static readonly Selector ThreadgroupMemoryDataSize = Selector.Register("threadgroupMemoryDataSize");
}
