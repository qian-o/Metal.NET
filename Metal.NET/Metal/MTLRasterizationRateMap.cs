namespace Metal.NET;

public class MTLRasterizationRateMap(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRasterizationRateMap>
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

    public void CopyParameterDataToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateMapBindings.CopyParameterDataToBuffer, buffer.NativePtr, offset);
    }

    public MTLSize PhysicalSizeForLayer(nuint layerIndex)
    {
        return ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapBindings.PhysicalSizeForLayer, layerIndex);
    }

    public MTLSamplePosition MapScreenToPhysicalCoordinates(MTLSamplePosition screenCoordinates, nuint layerIndex)
    {
        return ObjectiveC.MsgSendMTLSamplePosition(NativePtr, MTLRasterizationRateMapBindings.MapScreenToPhysicalCoordinates, screenCoordinates, layerIndex);
    }

    public MTLSamplePosition MapPhysicalToScreenCoordinates(MTLSamplePosition physicalCoordinates, nuint layerIndex)
    {
        return ObjectiveC.MsgSendMTLSamplePosition(NativePtr, MTLRasterizationRateMapBindings.MapPhysicalToScreenCoordinates, physicalCoordinates, layerIndex);
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

    public static readonly Selector PhysicalSizeForLayer = "physicalSizeForLayer:";

    public static readonly Selector ScreenSize = "screenSize";
}
