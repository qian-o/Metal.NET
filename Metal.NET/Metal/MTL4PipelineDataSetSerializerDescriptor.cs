namespace Metal.NET;

/// <summary>
/// Groups together properties to create a pipeline data set serializer.
/// </summary>
public class MTL4PipelineDataSetSerializerDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4PipelineDataSetSerializerDescriptor>
{
    #region INativeObject
    public static new MTL4PipelineDataSetSerializerDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4PipelineDataSetSerializerDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4PipelineDataSetSerializerDescriptor() : this(ObjectiveC.AllocInit(MTL4PipelineDataSetSerializerDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Specifies the configuration of the serialization process.
    /// </summary>
    public MTL4PipelineDataSetSerializerConfiguration Configuration
    {
        get => (MTL4PipelineDataSetSerializerConfiguration)ObjectiveC.MsgSendULong(NativePtr, MTL4PipelineDataSetSerializerDescriptorBindings.Configuration);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineDataSetSerializerDescriptorBindings.SetConfiguration, (nuint)value);
    }
    #endregion
}

file static class MTL4PipelineDataSetSerializerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4PipelineDataSetSerializerDescriptor");

    public static readonly Selector Configuration = "configuration";

    public static readonly Selector SetConfiguration = "setConfiguration:";
}
