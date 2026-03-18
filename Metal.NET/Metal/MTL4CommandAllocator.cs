namespace Metal.NET;

public class MTL4CommandAllocator(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommandAllocator>
{
    #region INativeObject
    public static new MTL4CommandAllocator Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommandAllocator New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4CommandAllocatorBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandAllocatorBindings.Label);
    }

    public ulong AllocatedSize()
    {
        return ObjectiveC.MsgSendULong(NativePtr, MTL4CommandAllocatorBindings.AllocatedSize);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandAllocatorBindings.Reset);
    }
}

file static class MTL4CommandAllocatorBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector Reset = "reset";
}
