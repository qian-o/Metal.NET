namespace Metal.NET;

public readonly struct MTLRasterizationRateMap(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
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
    public static readonly Selector CopyParameterDataToBuffer = Selector.Register("copyParameterDataToBuffer:offset:");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector LayerCount = Selector.Register("layerCount");

    public static readonly Selector ParameterBufferSizeAndAlign = Selector.Register("parameterBufferSizeAndAlign");

    public static readonly Selector PhysicalGranularity = Selector.Register("physicalGranularity");

    public static readonly Selector PhysicalSize = Selector.Register("physicalSizeForLayer:");

    public static readonly Selector ScreenSize = Selector.Register("screenSize");
}
