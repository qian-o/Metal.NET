namespace Metal.NET;

public class MTL4PipelineDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTL4PipelineDescriptor>
{
    public static MTL4PipelineDescriptor Create(nint nativePtr) => new(nativePtr);

    public MTL4PipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineDescriptorBindings.Class))
    {
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4PipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4PipelineDescriptorBindings.SetLabel, value);
    }

    public MTL4PipelineOptions Options
    {
        get => GetProperty(ref field, MTL4PipelineDescriptorBindings.Options);
        set => SetProperty(ref field, MTL4PipelineDescriptorBindings.SetOptions, value);
    }
}

file static class MTL4PipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector Options = "options";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOptions = "setOptions:";
}
