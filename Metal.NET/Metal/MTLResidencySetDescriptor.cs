namespace Metal.NET;

public class MTLResidencySetDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLResidencySetDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResidencySetDescriptorSelector.Class))
    {
    }

    public nuint InitialCapacity
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetDescriptorSelector.InitialCapacity);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetDescriptorSelector.SetInitialCapacity, value);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTLResidencySetDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResidencySetDescriptor");

    public static readonly Selector InitialCapacity = Selector.Register("initialCapacity");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetInitialCapacity = Selector.Register("setInitialCapacity:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
