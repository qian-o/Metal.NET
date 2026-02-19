namespace Metal.NET;

public readonly struct MTLResidencySetDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLResidencySetDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResidencySetDescriptorBindings.Class))
    {
    }

    public nuint InitialCapacity
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetDescriptorBindings.InitialCapacity);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetDescriptorBindings.SetInitialCapacity, value);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTLResidencySetDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResidencySetDescriptor");

    public static readonly Selector InitialCapacity = Selector.Register("initialCapacity");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetInitialCapacity = Selector.Register("setInitialCapacity:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
