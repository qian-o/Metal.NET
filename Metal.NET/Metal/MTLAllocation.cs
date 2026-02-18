namespace Metal.NET;

public partial class MTLAllocation : NativeObject
{
    public MTLAllocation(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAllocationSelector.AllocatedSize);
    }
}

file static class MTLAllocationSelector
{
    public static readonly Selector AllocatedSize = Selector.Register("allocatedSize");
}
