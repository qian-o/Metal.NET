namespace Metal.NET;

public class MTLAllocation(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAllocation>
{
    public static MTLAllocation Create(nint nativePtr) => new(nativePtr, true);

    public static MTLAllocation CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAllocationBindings.AllocatedSize);
    }
}

file static class MTLAllocationBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";
}
