namespace Metal.NET;

public readonly struct MTL4CommandAllocatorDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4CommandAllocatorDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CommandAllocatorDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandAllocatorDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandAllocatorDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTL4CommandAllocatorDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandAllocatorDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
