namespace Metal.NET;

public partial class MTLRasterizationRateMap(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRasterizationRateMap>
{
    #region INativeObject
    public static new MTLRasterizationRateMap Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRasterizationRateMap New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLRasterizationRateMapBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLRasterizationRateMapBindings.Label);
    }

    public MTLSize ScreenSize
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapBindings.ScreenSize);
    }

    public MTLSize PhysicalGranularity
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapBindings.PhysicalGranularity);
    }

    public nuint LayerCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRasterizationRateMapBindings.LayerCount);
    }

    public MTLSizeAndAlign ParameterBufferSizeAndAlign
    {
        get => ObjectiveC.MsgSendMTLSizeAndAlign(NativePtr, MTLRasterizationRateMapBindings.ParameterBufferSizeAndAlign);
    }

    public void CopyParameterData(MTLBuffer buffer, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateMapBindings.CopyParameterDataToBuffer_Offset, buffer.NativePtr, offset);
    }

    public MTLSize PhysicalSize(nuint layerIndex)
    {
        return ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapBindings.PhysicalSizeForLayer, layerIndex);
    }

    public MTLSamplePosition PhysicalCoordinates(MTLSamplePosition screenCoordinates, nuint layerIndex)
    {
        return ObjectiveC.MsgSendMTLSamplePosition(NativePtr, MTLRasterizationRateMapBindings.MapScreenToPhysicalCoordinates_ForLayer, screenCoordinates, layerIndex);
    }

    public MTLSamplePosition ScreenCoordinates(MTLSamplePosition physicalCoordinates, nuint layerIndex)
    {
        return ObjectiveC.MsgSendMTLSamplePosition(NativePtr, MTLRasterizationRateMapBindings.MapPhysicalToScreenCoordinates_ForLayer, physicalCoordinates, layerIndex);
    }
}

file static class MTLRasterizationRateMapBindings
{
    public static readonly Selector CopyParameterDataToBuffer_Offset = "copyParameterDataToBuffer:offset:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector LayerCount = "layerCount";

    public static readonly Selector MapPhysicalToScreenCoordinates_ForLayer = "mapPhysicalToScreenCoordinates:forLayer:";

    public static readonly Selector MapScreenToPhysicalCoordinates_ForLayer = "mapScreenToPhysicalCoordinates:forLayer:";

    public static readonly Selector ParameterBufferSizeAndAlign = "parameterBufferSizeAndAlign";

    public static readonly Selector PhysicalGranularity = "physicalGranularity";

    public static readonly Selector PhysicalSizeForLayer = "physicalSizeForLayer:";

    public static readonly Selector ScreenSize = "screenSize";
}
