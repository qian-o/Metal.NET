namespace Metal.NET;

public class MTLAllocation(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLAllocation>
{
    public static MTLAllocation Create(nint nativePtr) => new(nativePtr);

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAllocationBindings.AllocatedSize);
    }
}

file static class MTLAllocationBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";
}
