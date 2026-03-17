namespace Metal.NET;

/// <summary>
/// A compiled read-only instance that determines how to apply variable rasterization rates when rendering.
/// </summary>
public class MTLRasterizationRateMap(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRasterizationRateMap>
{
    #region INativeObject
    public static new MTLRasterizationRateMap Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRasterizationRateMap New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying the rate map - Properties

    /// <summary>
    /// The device object that created the rate map.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLRasterizationRateMapBindings.Device);
    }

    /// <summary>
    /// A string that identifies the rate map.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLRasterizationRateMapBindings.Label);
    }
    #endregion

    #region Inspecting geometric and rendering properties - Properties

    /// <summary>
    /// The number of layers in the rate map.
    /// </summary>
    public nuint LayerCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRasterizationRateMapBindings.LayerCount);
    }

    /// <summary>
    /// The logical size, in pixels, of the viewport coordinate system.
    /// </summary>
    public MTLSize ScreenSize
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapBindings.ScreenSize);
    }

    /// <summary>
    /// The granularity, in physical pixels, at which the rasterization rate varies.
    /// </summary>
    public MTLSize PhysicalGranularity
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapBindings.PhysicalGranularity);
    }
    #endregion

    public MTLSizeAndAlign ParameterBufferSizeAndAlign
    {
        get => ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLRasterizationRateMapBindings.ParameterBufferSizeAndAlign);
    }

    #region Inspecting geometric and rendering properties - Methods

    /// <summary>
    /// Returns the dimensions, in pixels, of the area in the render target affected by the rasterization rate map.
    /// </summary>
    public MTLSize PhysicalSize(nuint layerIndex)
    {
        return ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapBindings.PhysicalSize, layerIndex);
    }
    #endregion

    #region Obtaining coordinate transformation data - Methods

    /// <summary>
    /// Copies the parameter data into the provided buffer.
    /// </summary>
    public void CopyParameterDataToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateMapBindings.CopyParameterDataToBuffer, buffer.NativePtr, offset);
    }
    #endregion

    public MTLSamplePosition MapPhysicalToScreenCoordinates(MTLSamplePosition physicalCoordinates, nuint layerIndex)
    {
        return ObjectiveC.MsgSendMTLSamplePosition(NativePtr, MTLRasterizationRateMapBindings.MapPhysicalToScreenCoordinates, physicalCoordinates, layerIndex);
    }

    public MTLSamplePosition MapScreenToPhysicalCoordinates(MTLSamplePosition screenCoordinates, nuint layerIndex)
    {
        return ObjectiveC.MsgSendMTLSamplePosition(NativePtr, MTLRasterizationRateMapBindings.MapScreenToPhysicalCoordinates, screenCoordinates, layerIndex);
    }
}

file static class MTLRasterizationRateMapBindings
{
    public static readonly Selector CopyParameterDataToBuffer = "copyParameterDataToBuffer:offset:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector LayerCount = "layerCount";

    public static readonly Selector MapPhysicalToScreenCoordinates = "mapPhysicalToScreenCoordinates:forLayer:";

    public static readonly Selector MapScreenToPhysicalCoordinates = "mapScreenToPhysicalCoordinates:forLayer:";

    public static readonly Selector ParameterBufferSizeAndAlign = "parameterBufferSizeAndAlign";

    public static readonly Selector PhysicalGranularity = "physicalGranularity";

    public static readonly Selector PhysicalSize = "physicalSizeForLayer:";

    public static readonly Selector ScreenSize = "screenSize";
}
