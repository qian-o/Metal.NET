namespace Metal.NET;

public class MTLAllocation(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLAllocation>
{
    public static new MTLAllocation Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAllocation Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAllocationBindings.AllocatedSize);
    }
}

file static class MTLAllocationBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";
}
