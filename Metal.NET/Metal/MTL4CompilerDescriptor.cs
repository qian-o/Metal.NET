namespace Metal.NET;

public class MTL4CompilerDescriptor(nint nativePtr, bool ownsReference, bool allowGCRelease) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTL4CompilerDescriptor>
{
    public static MTL4CompilerDescriptor Null { get; } = new(0, false, false);

    public static MTL4CompilerDescriptor Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public MTL4CompilerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerDescriptorBindings.Class), true, true)
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
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CompilerDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector PipelineDataSetSerializer = "pipelineDataSetSerializer";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetPipelineDataSetSerializer = "setPipelineDataSetSerializer:";
}
