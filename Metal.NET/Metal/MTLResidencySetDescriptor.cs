namespace Metal.NET;

public class MTLResidencySetDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
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

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
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
