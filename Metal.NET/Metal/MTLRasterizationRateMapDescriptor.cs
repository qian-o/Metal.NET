namespace Metal.NET;

public class MTLRasterizationRateMapDescriptor : IDisposable
{
    public MTLRasterizationRateMapDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRasterizationRateMapDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRasterizationRateMapDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRasterizationRateMapDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRasterizationRateMapDescriptor");

    public MTLRasterizationRateMapDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLabel, value.NativePtr);
    }

    public nuint LayerCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRasterizationRateMapDescriptorSelector.LayerCount);
    }

    public MTLRasterizationRateLayerArray Layers
    {
        get => new MTLRasterizationRateLayerArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Layers));
    }

    public MTLRasterizationRateLayerDescriptor Layer(uint layerIndex)
    {
        MTLRasterizationRateLayerDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Layer, (nuint)layerIndex));

        return result;
    }

    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, uint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLayerLayerIndex, layer.NativePtr, (nuint)layerIndex);
    }

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize)
    {
        MTLRasterizationRateMapDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLRasterizationRateMapDescriptorSelector.RasterizationRateMapDescriptor, screenSize));

        return result;
    }

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize, MTLRasterizationRateLayerDescriptor layer)
    {
        MTLRasterizationRateMapDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLRasterizationRateMapDescriptorSelector.RasterizationRateMapDescriptorLayer, screenSize, layer.NativePtr));

        return result;
    }

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize, uint layerCount, int layers)
    {
        MTLRasterizationRateMapDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLRasterizationRateMapDescriptorSelector.RasterizationRateMapDescriptorLayerCountLayers, screenSize, (nuint)layerCount, layers));

        return result;
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

    public static readonly Selector Layer = Selector.Register("layer:");

    public static readonly Selector SetLayerLayerIndex = Selector.Register("setLayer:layerIndex:");

    public static readonly Selector RasterizationRateMapDescriptor = Selector.Register("rasterizationRateMapDescriptor:");

    public static readonly Selector RasterizationRateMapDescriptorLayer = Selector.Register("rasterizationRateMapDescriptor:layer:");

    public static readonly Selector RasterizationRateMapDescriptorLayerCountLayers = Selector.Register("rasterizationRateMapDescriptor:layerCount:layers:");
}
