namespace Metal.NET;

public partial class MTL4CompilerDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CompilerDescriptor>
{
    #region INativeObject
    public static new MTL4CompilerDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CompilerDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4CompilerDescriptor() : this(ObjectiveC.AllocInit(MTL4CompilerDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CompilerDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4CompilerDescriptorBindings.SetLabel, value);
    }

    public MTL4PipelineDataSetSerializer PipelineDataSetSerializer
    {
        get => GetProperty(ref field, MTL4CompilerDescriptorBindings.PipelineDataSetSerializer);
        set => SetProperty(ref field, MTL4CompilerDescriptorBindings.SetPipelineDataSetSerializer, value);
    }
}

file static class MTL4CompilerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CompilerDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector PipelineDataSetSerializer = "pipelineDataSetSerializer";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetPipelineDataSetSerializer = "setPipelineDataSetSerializer:";
}
