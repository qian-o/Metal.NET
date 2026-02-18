namespace Metal.NET;

public partial class MTLRasterizationRateMap : NativeObject
{
    public MTLRasterizationRateMap(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint LayerCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRasterizationRateMapSelector.LayerCount);
    }

    public MTLSizeAndAlign ParameterBufferSizeAndAlign
    {
        get => ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLRasterizationRateMapSelector.ParameterBufferSizeAndAlign);
    }

    public MTLSize PhysicalGranularity
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapSelector.PhysicalGranularity);
    }

    public MTLSize ScreenSize
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapSelector.ScreenSize);
    }

    public void CopyParameterDataToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapSelector.CopyParameterDataToBuffer, buffer.NativePtr, offset);
    }

    public MTLSamplePosition MapPhysicalToScreenCoordinates(MTLSamplePosition physicalCoordinates, nuint layerIndex)
    {
        return ObjectiveCRuntime.MsgSendMTLSamplePosition(NativePtr, MTLRasterizationRateMapSelector.MapPhysicalToScreenCoordinates, physicalCoordinates, layerIndex);
    }

    public MTLSamplePosition MapScreenToPhysicalCoordinates(MTLSamplePosition screenCoordinates, nuint layerIndex)
    {
        return ObjectiveCRuntime.MsgSendMTLSamplePosition(NativePtr, MTLRasterizationRateMapSelector.MapScreenToPhysicalCoordinates, screenCoordinates, layerIndex);
    }

    public MTLSize PhysicalSize(nuint layerIndex)
    {
        return ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapSelector.PhysicalSize, layerIndex);
    }
}

file static class MTLRasterizationRateMapSelector
{
    public static readonly Selector CopyParameterDataToBuffer = Selector.Register("copyParameterDataToBuffer::");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector LayerCount = Selector.Register("layerCount");

    public static readonly Selector MapPhysicalToScreenCoordinates = Selector.Register("mapPhysicalToScreenCoordinates::");

    public static readonly Selector MapScreenToPhysicalCoordinates = Selector.Register("mapScreenToPhysicalCoordinates::");

    public static readonly Selector ParameterBufferSizeAndAlign = Selector.Register("parameterBufferSizeAndAlign");

    public static readonly Selector PhysicalGranularity = Selector.Register("physicalGranularity");

    public static readonly Selector PhysicalSize = Selector.Register("physicalSize:");

    public static readonly Selector ScreenSize = Selector.Register("screenSize");
}
