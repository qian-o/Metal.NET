namespace Metal.NET;

public class MTL4PipelineDataSetSerializerDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTL4PipelineDataSetSerializerDescriptor>
{
    public static MTL4PipelineDataSetSerializerDescriptor Create(nint nativePtr) => new(nativePtr);
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

    public static readonly Selector Configuration = "configuration";

    public static readonly Selector SetConfiguration = "setConfiguration:";
}
