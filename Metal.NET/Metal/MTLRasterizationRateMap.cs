namespace Metal.NET;

public class MTLRasterizationRateMap(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLDevice? Device
    {
        get => GetProperty(ref field, MTLRasterizationRateMapBindings.Device);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTLRasterizationRateMapBindings.Label);
    }

    public nuint LayerCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRasterizationRateMapBindings.LayerCount);
    }

    public MTLSizeAndAlign ParameterBufferSizeAndAlign
    {
        get => ObjectiveCRuntime.MsgSendMTLSizeAndAlign(NativePtr, MTLRasterizationRateMapBindings.ParameterBufferSizeAndAlign);
    }

    public MTLSize PhysicalGranularity
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapBindings.PhysicalGranularity);
    }

    public MTLSize ScreenSize
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapBindings.ScreenSize);
    }

    public void CopyParameterDataToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapBindings.CopyParameterDataToBuffer, buffer.NativePtr, offset);
    }

    public MTLSize PhysicalSize(nuint layerIndex)
    {
        return ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapBindings.PhysicalSize, layerIndex);
    }
}

file static class MTLRasterizationRateMapBindings
{
    public static readonly Selector CopyParameterDataToBuffer = "copyParameterDataToBuffer:offset:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector LayerCount = "layerCount";

    public static readonly Selector ParameterBufferSizeAndAlign = "parameterBufferSizeAndAlign";

    public static readonly Selector PhysicalGranularity = "physicalGranularity";

    public static readonly Selector PhysicalSize = "physicalSizeForLayer:";

    public static readonly Selector ScreenSize = "screenSize";
}
