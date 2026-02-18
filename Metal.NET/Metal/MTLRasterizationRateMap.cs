namespace Metal.NET;

public class MTLRasterizationRateMap : IDisposable
{
    public MTLRasterizationRateMap(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLRasterizationRateMap()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapSelector.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapSelector.Label));
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapSelector.CopyParameterDataToBufferOffset, buffer.NativePtr, offset);
    }

    public MTLSamplePosition MapPhysicalToScreenCoordinates(MTLSamplePosition physicalCoordinates, nuint layerIndex)
    {
        MTLSamplePosition result = ObjectiveCRuntime.MsgSendMTLSamplePosition(NativePtr, MTLRasterizationRateMapSelector.MapPhysicalToScreenCoordinatesLayerIndex, physicalCoordinates, layerIndex);

        return result;
    }

    public MTLSamplePosition MapScreenToPhysicalCoordinates(MTLSamplePosition screenCoordinates, nuint layerIndex)
    {
        MTLSamplePosition result = ObjectiveCRuntime.MsgSendMTLSamplePosition(NativePtr, MTLRasterizationRateMapSelector.MapScreenToPhysicalCoordinatesLayerIndex, screenCoordinates, layerIndex);

        return result;
    }

    public MTLSize PhysicalSize(nuint layerIndex)
    {
        MTLSize result = ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapSelector.PhysicalSize, layerIndex);

        return result;
    }

    public static implicit operator nint(MTLRasterizationRateMap value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRasterizationRateMap(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLRasterizationRateMapSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector LayerCount = Selector.Register("layerCount");

    public static readonly Selector ParameterBufferSizeAndAlign = Selector.Register("parameterBufferSizeAndAlign");

    public static readonly Selector PhysicalGranularity = Selector.Register("physicalGranularity");

    public static readonly Selector ScreenSize = Selector.Register("screenSize");

    public static readonly Selector CopyParameterDataToBufferOffset = Selector.Register("copyParameterDataToBuffer:offset:");

    public static readonly Selector MapPhysicalToScreenCoordinatesLayerIndex = Selector.Register("mapPhysicalToScreenCoordinates:layerIndex:");

    public static readonly Selector MapScreenToPhysicalCoordinatesLayerIndex = Selector.Register("mapScreenToPhysicalCoordinates:layerIndex:");

    public static readonly Selector PhysicalSize = Selector.Register("physicalSize:");
}
