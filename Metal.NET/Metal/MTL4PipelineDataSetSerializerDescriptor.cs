namespace Metal.NET;

public class MTL4PipelineDataSetSerializerDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4PipelineDataSetSerializerDescriptor>
{
    public static MTL4PipelineDataSetSerializerDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4PipelineDataSetSerializerDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4PipelineDataSetSerializerDescriptor() : this(ObjectiveC.AllocInit(MTL4PipelineDataSetSerializerDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTL4PipelineDataSetSerializerConfiguration Configuration
    {
        get => (MTL4PipelineDataSetSerializerConfiguration)ObjectiveC.MsgSendULong(NativePtr, MTL4PipelineDataSetSerializerDescriptorBindings.Configuration);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineDataSetSerializerDescriptorBindings.SetConfiguration, (nuint)value);
    }
}

file static class MTL4PipelineDataSetSerializerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4PipelineDataSetSerializerDescriptor");

    public static readonly Selector Configuration = "configuration";

    public static readonly Selector SetConfiguration = "setConfiguration:";
}
