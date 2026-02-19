namespace Metal.NET;

public class MTL4CompilerDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CompilerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTL4CompilerDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4CompilerDescriptorBindings.SetLabel, value);
    }

    public MTL4PipelineDataSetSerializer? PipelineDataSetSerializer
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
