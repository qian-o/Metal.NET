namespace Metal.NET;

public class MTLRasterizationRateMap : IDisposable
{
    public MTLRasterizationRateMap(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRasterizationRateMap()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapSelector.Device));

    public NSString Label => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapSelector.Label));

    public nuint LayerCount => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRasterizationRateMapSelector.LayerCount);

    public void CopyParameterDataToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapSelector.CopyParameterDataToBufferOffset, buffer.NativePtr, offset);
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
