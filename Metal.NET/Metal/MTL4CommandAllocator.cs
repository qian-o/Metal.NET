namespace Metal.NET;

public readonly struct MTL4CommandAllocator(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CommandAllocatorBindings.AllocatedSize);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandAllocatorBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandAllocatorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandAllocatorBindings.Reset);
    }
}

file static class MTL4CommandAllocatorBindings
{
    public static readonly Selector AllocatedSize = Selector.Register("allocatedSize");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Reset = Selector.Register("reset");
}
