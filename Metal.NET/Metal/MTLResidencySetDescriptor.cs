namespace Metal.NET;

public class MTLResidencySetDescriptor(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLResidencySetDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResidencySetDescriptorBindings.Class), true)
    {
    }

    public nuint InitialCapacity
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetDescriptorBindings.InitialCapacity);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetDescriptorBindings.SetInitialCapacity, value);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTLResidencySetDescriptorBindings.Label);
        set => SetProperty(ref field, MTLResidencySetDescriptorBindings.SetLabel, value);
    }
}

file static class MTLResidencySetDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResidencySetDescriptor");

    public static readonly Selector InitialCapacity = "initialCapacity";

    public static readonly Selector Label = "label";

    public static readonly Selector SetInitialCapacity = "setInitialCapacity:";

    public static readonly Selector SetLabel = "setLabel:";
}
