namespace Metal.NET;

public partial class MTLRasterizationRateMapDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateMapDescriptor");

    public MTLRasterizationRateMapDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public nuint LayerCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRasterizationRateMapDescriptorSelector.LayerCount);
    }

    public MTLRasterizationRateLayerArray? Layers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Layers);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLSize ScreenSize
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapDescriptorSelector.ScreenSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetScreenSize, value);
    }

    public MTLRasterizationRateLayerDescriptor? Layer(nuint layerIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Layer, layerIndex);
        return ptr is not 0 ? new(ptr) : null;
    }

    public static MTLRasterizationRateMapDescriptor? RasterizationRateMapDescriptor(MTLSize screenSize)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLRasterizationRateMapDescriptorSelector.RasterizationRateMapDescriptor, screenSize);
        return ptr is not 0 ? new(ptr) : null;
    }

    public static MTLRasterizationRateMapDescriptor? RasterizationRateMapDescriptor(MTLSize screenSize, MTLRasterizationRateLayerDescriptor layer)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLRasterizationRateMapDescriptorSelector.RasterizationRateMapDescriptor, screenSize, layer.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLayer, layer.NativePtr, layerIndex);
    }
}

file static class MTLRasterizationRateMapDescriptorSelector
{
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
