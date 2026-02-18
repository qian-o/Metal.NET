namespace Metal.NET;

public partial class MTL4PipelineDataSetSerializerDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineDataSetSerializerDescriptor");

    public MTL4PipelineDataSetSerializerDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTL4PipelineDataSetSerializerConfiguration Configuration
    {
        get => (MTL4PipelineDataSetSerializerConfiguration)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PipelineDataSetSerializerDescriptorSelector.Configuration);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDataSetSerializerDescriptorSelector.SetConfiguration, (nuint)value);
    }
}

file static class MTL4PipelineDataSetSerializerDescriptorSelector
{
    public static readonly Selector Configuration = Selector.Register("configuration");

    public static readonly Selector SetConfiguration = Selector.Register("setConfiguration:");
}
