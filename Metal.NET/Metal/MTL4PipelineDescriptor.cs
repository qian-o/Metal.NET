namespace Metal.NET;

/// <summary>Base type for descriptors you use for building pipeline state objects.</summary>
public class MTL4PipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4PipelineDescriptor>
{
    #region INativeObject
    public static new MTL4PipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4PipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4PipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4PipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>Assigns an optional string that uniquely identifies a pipeline descriptor.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4PipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4PipelineDescriptorBindings.SetLabel, value);
    }

    /// <summary>Provides compile-time options when you build the pipeline.</summary>
    public MTL4PipelineOptions Options
    {
        get => GetProperty(ref field, MTL4PipelineDescriptorBindings.Options);
        set => SetProperty(ref field, MTL4PipelineDescriptorBindings.SetOptions, value);
    }
    #endregion
}

file static class MTL4PipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4PipelineDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector Options = "options";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOptions = "setOptions:";
}
