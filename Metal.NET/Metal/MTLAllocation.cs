namespace Metal.NET;

public readonly struct MTLAllocation(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAllocationBindings.AllocatedSize);
    }
}

file static class MTLAllocationBindings
{
    public static readonly Selector AllocatedSize = Selector.Register("allocatedSize");
}
