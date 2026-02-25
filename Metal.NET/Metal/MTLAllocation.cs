namespace Metal.NET;

public class MTLAllocation(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAllocation>
{
    public static MTLAllocation Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTLAllocation Null => Create(0, false);
    public static MTLAllocation Empty => Null;

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAllocationBindings.AllocatedSize);
    }
}

file static class MTLAllocationBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";
}
