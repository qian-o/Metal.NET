namespace Metal.NET;

public class MTL4PipelineDataSetSerializerDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4PipelineDataSetSerializerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineDataSetSerializerDescriptorBindings.Class))
    {
    }

    public MTL4PipelineDataSetSerializerConfiguration Configuration
    {
        get => (MTL4PipelineDataSetSerializerConfiguration)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PipelineDataSetSerializerDescriptorBindings.Configuration);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDataSetSerializerDescriptorBindings.SetConfiguration, (nuint)value);
    }
}

file static class MTL4PipelineDataSetSerializerDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineDataSetSerializerDescriptor");

    public static readonly Selector Configuration = Selector.Register("configuration");

    public static readonly Selector SetConfiguration = Selector.Register("setConfiguration:");
}
