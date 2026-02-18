namespace Metal.NET;

public partial class MTLResidencySetDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResidencySetDescriptor");

    public MTLResidencySetDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint InitialCapacity
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetDescriptorSelector.InitialCapacity);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetDescriptorSelector.SetInitialCapacity, value);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetDescriptorSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTLResidencySetDescriptorSelector
{
    public static readonly Selector InitialCapacity = Selector.Register("initialCapacity");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetInitialCapacity = Selector.Register("setInitialCapacity:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
