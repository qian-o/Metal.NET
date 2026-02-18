namespace Metal.NET;

public class MTL4CommandAllocator(nint nativePtr) : NativeObject(nativePtr)
{

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CommandAllocatorSelector.AllocatedSize);
    }

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandAllocatorSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandAllocatorSelector.Label));
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
