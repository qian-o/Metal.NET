namespace Metal.NET;

public class MTL4CompilerDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CompilerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerDescriptorBindings.Label);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTL4PipelineDataSetSerializer? PipelineDataSetSerializer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerDescriptorBindings.PipelineDataSetSerializer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4PipelineDataSetSerializer(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerDescriptorBindings.SetPipelineDataSetSerializer, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTL4CompilerDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CompilerDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector PipelineDataSetSerializer = Selector.Register("pipelineDataSetSerializer");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetPipelineDataSetSerializer = Selector.Register("setPipelineDataSetSerializer:");
}
