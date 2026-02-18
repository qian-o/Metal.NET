namespace Metal.NET;

public class MTLAllocation(nint nativePtr) : NativeObject(nativePtr)
{

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAllocationSelector.AllocatedSize);
    }
}

file static class MTLAllocationSelector
{
    public static readonly Selector AllocatedSize = Selector.Register("allocatedSize");
}
