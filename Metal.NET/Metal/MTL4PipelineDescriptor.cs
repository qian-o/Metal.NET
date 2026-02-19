namespace Metal.NET;

public class MTL4PipelineDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4PipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDescriptorBindings.Label);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTL4PipelineOptions? Options
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDescriptorBindings.Options);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4PipelineOptions(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDescriptorBindings.SetOptions, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTL4PipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
