namespace Metal.NET;

public class MTLRasterizationRateMapDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateMapDescriptor");

    public MTLRasterizationRateMapDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLRasterizationRateMapDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLRasterizationRateMapDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLabel, value.NativePtr);
    }

    public nuint LayerCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRasterizationRateMapDescriptorSelector.LayerCount);
    }

    public MTLRasterizationRateLayerArray Layers
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Layers));
    }

    public MTLSize ScreenSize
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapDescriptorSelector.ScreenSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetScreenSize, value);
    }

    public static implicit operator nint(MTLRasterizationRateMapDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRasterizationRateMapDescriptor(nint value)
    {
        return new(value);
    }

    public MTLRasterizationRateLayerDescriptor Layer(nuint layerIndex)
    {
        MTLRasterizationRateLayerDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.LayerAtIndex, layerIndex));

        return result;
    }

    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLayerAtIndex, layer.NativePtr, layerIndex);
    }

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize)
    {
        MTLRasterizationRateMapDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLRasterizationRateMapDescriptorSelector.RasterizationRateMapDescriptorWithScreenSizeLayerCountLayers, screenSize));

        return result;
    }

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize, MTLRasterizationRateLayerDescriptor layer)
    {
        MTLRasterizationRateMapDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLRasterizationRateMapDescriptorSelector.RasterizationRateMapDescriptorWithScreenSizeLayerCountLayers, screenSize, layer.NativePtr));

        return result;
    }

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize, nuint layerCount, nint layers)
    {
        MTLRasterizationRateMapDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLRasterizationRateMapDescriptorSelector.RasterizationRateMapDescriptorWithScreenSizeLayerCountLayers, screenSize, layerCount, layers));

        return result;
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

file class MTLRasterizationRateMapDescriptorSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector LayerCount = Selector.Register("layerCount");

    public static readonly Selector Layers = Selector.Register("layers");

    public static readonly Selector ScreenSize = Selector.Register("screenSize");

    public static readonly Selector SetScreenSize = Selector.Register("setScreenSize:");

    public static readonly Selector LayerAtIndex = Selector.Register("layerAtIndex:");

    public static readonly Selector SetLayerAtIndex = Selector.Register("setLayer:atIndex:");

    public static readonly Selector RasterizationRateMapDescriptorWithScreenSizeLayerCountLayers = Selector.Register("rasterizationRateMapDescriptorWithScreenSize:layerCount:layers:");
}
