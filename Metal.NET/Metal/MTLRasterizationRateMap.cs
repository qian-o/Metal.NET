namespace Metal.NET;

public class MTLRasterizationRateMap(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapSelector.Label));
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

    public MTLSize PhysicalSize(nuint layerIndex)
    {
        return ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapSelector.PhysicalSize, layerIndex);
    }
}

file static class MTLRasterizationRateMapSelector
{
    public static readonly Selector CopyParameterDataToBuffer = Selector.Register("copyParameterDataToBuffer:offset:");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector LayerCount = Selector.Register("layerCount");

    public static readonly Selector ParameterBufferSizeAndAlign = Selector.Register("parameterBufferSizeAndAlign");

    public static readonly Selector PhysicalGranularity = Selector.Register("physicalGranularity");

    public static readonly Selector PhysicalSize = Selector.Register("physicalSizeForLayer:");

    public static readonly Selector ScreenSize = Selector.Register("screenSize");
}
