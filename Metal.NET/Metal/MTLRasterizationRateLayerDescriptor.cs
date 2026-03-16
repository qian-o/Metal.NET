namespace Metal.NET;

/// <summary>The minimum rasterization rates to apply to sections of a layer in the render target.</summary>
public class MTLRasterizationRateLayerDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRasterizationRateLayerDescriptor>
{
    #region INativeObject
    public static new MTLRasterizationRateLayerDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRasterizationRateLayerDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRasterizationRateLayerDescriptor() : this(ObjectiveC.AllocInit(MTLRasterizationRateLayerDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Inspecting the layer rate function parameters - Properties

    /// <summary>The number of rows and columns in the layer map.</summary>
    public MTLSize SampleCount
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateLayerDescriptorBindings.SampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateLayerDescriptorBindings.SetSampleCount, value);
    }

    /// <summary>The maximum number of rows and columns in the layer map.</summary>
    public MTLSize MaxSampleCount
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateLayerDescriptorBindings.MaxSampleCount);
    }

    /// <summary>The horizontal rasterization rates for the layer map’s rows.</summary>
    public MTLRasterizationRateSampleArray Horizontal
    {
        get => GetProperty(ref field, MTLRasterizationRateLayerDescriptorBindings.Horizontal);
    }

    /// <summary>The vertical rasterization rates for the layer map’s rows.</summary>
    public MTLRasterizationRateSampleArray Vertical
    {
        get => GetProperty(ref field, MTLRasterizationRateLayerDescriptorBindings.Vertical);
    }
    #endregion

    public float HorizontalSampleStorage
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLRasterizationRateLayerDescriptorBindings.HorizontalSampleStorage);
    }

    public float VerticalSampleStorage
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLRasterizationRateLayerDescriptorBindings.VerticalSampleStorage);
    }
}

file static class MTLRasterizationRateLayerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRasterizationRateLayerDescriptor");

    public static readonly Selector Horizontal = "horizontal";

    public static readonly Selector HorizontalSampleStorage = "horizontalSampleStorage";

    public static readonly Selector MaxSampleCount = "maxSampleCount";

    public static readonly Selector SampleCount = "sampleCount";

    public static readonly Selector SetSampleCount = "setSampleCount:";

    public static readonly Selector Vertical = "vertical";

    public static readonly Selector VerticalSampleStorage = "verticalSampleStorage";
}
