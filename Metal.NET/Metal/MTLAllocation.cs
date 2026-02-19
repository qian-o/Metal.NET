namespace Metal.NET;

public class MTLAllocation(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
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
