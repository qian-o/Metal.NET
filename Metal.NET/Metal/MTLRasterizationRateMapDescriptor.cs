namespace Metal.NET;

public class MTLRasterizationRateMapDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRasterizationRateMapDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateMapDescriptorSelector.Class))
    {
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public nuint LayerCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRasterizationRateMapDescriptorSelector.LayerCount);
    }

    public MTLRasterizationRateLayerArray? Layers
    {
        get => GetNullableObject<MTLRasterizationRateLayerArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Layers));
    }

    public MTLSize ScreenSize
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapDescriptorSelector.ScreenSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetScreenSize, value);
    }

    public MTLRasterizationRateLayerDescriptor? Layer(nuint layerIndex)
    {
        return GetNullableObject<MTLRasterizationRateLayerDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorSelector.Layer, layerIndex));
    }

    public static MTLRasterizationRateMapDescriptor? RasterizationRateMapDescriptor(MTLSize screenSize)
    {
        return GetNullableObject<MTLRasterizationRateMapDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLRasterizationRateMapDescriptorSelector.Class, MTLRasterizationRateMapDescriptorSelector.RasterizationRateMapDescriptor, screenSize));
    }

    public static MTLRasterizationRateMapDescriptor? RasterizationRateMapDescriptor(MTLSize screenSize, MTLRasterizationRateLayerDescriptor layer)
    {
        return GetNullableObject<MTLRasterizationRateMapDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLRasterizationRateMapDescriptorSelector.Class, MTLRasterizationRateMapDescriptorSelector.RasterizationRateMapDescriptor, screenSize, layer.NativePtr));
    }

    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorSelector.SetLayer, layer.NativePtr, layerIndex);
    }
}

file static class MTLRasterizationRateMapDescriptorSelector
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
