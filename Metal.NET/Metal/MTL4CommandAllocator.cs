namespace Metal.NET;

public partial class MTL4CommandAllocator : NativeObject
{
    public MTL4CommandAllocator(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CommandAllocatorSelector.AllocatedSize);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandAllocatorSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandAllocatorSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandAllocatorSelector.Reset);
    }
}

file static class MTL4CommandAllocatorSelector
{
    public static readonly Selector AllocatedSize = Selector.Register("allocatedSize");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Reset = Selector.Register("reset");
}
