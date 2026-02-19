namespace Metal.NET;

public readonly struct MTLThreadgroupBinding(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

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
    public static readonly Selector ThreadgroupMemoryAlignment = Selector.Register("threadgroupMemoryAlignment");

    public static readonly Selector ThreadgroupMemoryDataSize = Selector.Register("threadgroupMemoryDataSize");
}
