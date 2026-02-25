namespace Metal.NET;

public class MTL4CompilerDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4CompilerDescriptor>
{
    public static MTL4CompilerDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTL4CompilerDescriptor Null => Create(0, false);
    public static MTL4CompilerDescriptor Empty => Null;

    public MTL4CompilerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerDescriptorBindings.Class), true)
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
