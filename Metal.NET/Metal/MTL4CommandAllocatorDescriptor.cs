namespace Metal.NET;

public class MTL4CommandAllocatorDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CommandAllocatorDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CommandAllocatorDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandAllocatorDescriptorBindings.Label);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandAllocatorDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTL4CommandAllocatorDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandAllocatorDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
