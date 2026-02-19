namespace Metal.NET;

public readonly struct MTLRasterizationRateMapDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRasterizationRateMapDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateMapDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public nuint LayerCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRasterizationRateMapDescriptorBindings.LayerCount);
    }

    public MTLRasterizationRateLayerArray? Layers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorBindings.Layers);
            return ptr is not 0 ? new MTLRasterizationRateLayerArray(ptr) : default;
        }
    }

    public MTLSize ScreenSize
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapDescriptorBindings.ScreenSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorBindings.SetScreenSize, value);
    }

    public MTLRasterizationRateLayerDescriptor? Layer(nuint layerIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorBindings.Layer, layerIndex);
        return ptr is not 0 ? new MTLRasterizationRateLayerDescriptor(ptr) : default;
    }

    public static MTLRasterizationRateMapDescriptor? RasterizationRateMapDescriptor(MTLSize screenSize)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLRasterizationRateMapDescriptorBindings.Class, MTLRasterizationRateMapDescriptorBindings.RasterizationRateMapDescriptor, screenSize);
        return ptr is not 0 ? new MTLRasterizationRateMapDescriptor(ptr) : default;
    }

    public static MTLRasterizationRateMapDescriptor? RasterizationRateMapDescriptor(MTLSize screenSize, MTLRasterizationRateLayerDescriptor layer)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLRasterizationRateMapDescriptorBindings.Class, MTLRasterizationRateMapDescriptorBindings.RasterizationRateMapDescriptor, screenSize, layer.NativePtr);
        return ptr is not 0 ? new MTLRasterizationRateMapDescriptor(ptr) : default;
    }

    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorBindings.SetLayer, layer.NativePtr, layerIndex);
    }
}

file static class MTLRasterizationRateMapDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateMapDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Layer = Selector.Register("layerAtIndex:");

    public static readonly Selector LayerCount = Selector.Register("layerCount");

    public static readonly Selector Layers = Selector.Register("layers");

    public static readonly Selector RasterizationRateMapDescriptor = Selector.Register("rasterizationRateMapDescriptorWithScreenSize:");

    public static readonly Selector ScreenSize = Selector.Register("screenSize");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetLayer = Selector.Register("setLayer:atIndex:");

    public static readonly Selector SetScreenSize = Selector.Register("setScreenSize:");
}
