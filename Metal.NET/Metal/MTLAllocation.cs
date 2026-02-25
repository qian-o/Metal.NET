namespace Metal.NET;

public class MTLAllocation(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLAllocation>
{
    public static MTLAllocation Null { get; } = new(0, false);

    public static MTLAllocation Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAllocationBindings.AllocatedSize);
    }
}

file static class MTLAllocationBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";
}
