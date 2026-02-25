namespace Metal.NET;

public class MTL4PipelineDataSetSerializerDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4PipelineDataSetSerializerDescriptor>
{
    public static MTL4PipelineDataSetSerializerDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static MTL4PipelineDataSetSerializerDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTL4PipelineDataSetSerializerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineDataSetSerializerDescriptorBindings.Class), true)
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
