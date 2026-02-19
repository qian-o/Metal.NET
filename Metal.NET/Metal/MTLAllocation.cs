namespace Metal.NET;

public class MTLAllocation(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAllocationBindings.AllocatedSize);
    }
}

file static class MTLAllocationBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";
}
