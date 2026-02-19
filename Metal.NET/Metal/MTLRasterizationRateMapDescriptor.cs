namespace Metal.NET;

public class MTLRasterizationRateMapDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRasterizationRateMapDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRasterizationRateMapDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get => GetProperty<NSString>(ref field, MTLRasterizationRateMapDescriptorBindings.Label);
        set => SetProperty(ref field, MTLRasterizationRateMapDescriptorBindings.SetLabel, value);
    }

    public nuint LayerCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRasterizationRateMapDescriptorBindings.LayerCount);
    }

    public MTLRasterizationRateLayerArray? Layers
    {
        get => GetProperty<MTLRasterizationRateLayerArray>(ref field, MTLRasterizationRateMapDescriptorBindings.Layers);
    }

    public MTLSize ScreenSize
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapDescriptorBindings.ScreenSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorBindings.SetScreenSize, value);
    }

    public MTLRasterizationRateLayerDescriptor? Layer(nuint layerIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorBindings.Layer, layerIndex);
        return ptr is not 0 ? new MTLRasterizationRateLayerDescriptor(ptr) : null;
    }

    public static MTLRasterizationRateMapDescriptor? RasterizationRateMapDescriptor(MTLSize screenSize)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLRasterizationRateMapDescriptorBindings.Class, MTLRasterizationRateMapDescriptorBindings.RasterizationRateMapDescriptor, screenSize);
        return ptr is not 0 ? new MTLRasterizationRateMapDescriptor(ptr) : null;
    }

    public static MTLRasterizationRateMapDescriptor? RasterizationRateMapDescriptor(MTLSize screenSize, MTLRasterizationRateLayerDescriptor layer)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLRasterizationRateMapDescriptorBindings.Class, MTLRasterizationRateMapDescriptorBindings.RasterizationRateMapDescriptor, screenSize, layer.NativePtr);
        return ptr is not 0 ? new MTLRasterizationRateMapDescriptor(ptr) : null;
    }

    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorBindings.SetLayer, layer.NativePtr, layerIndex);
    }
}

file static class MTLRasterizationRateMapDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateMapDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector Layer = "layerAtIndex:";

    public static readonly Selector LayerCount = "layerCount";

    public static readonly Selector Layers = "layers";

    public static readonly Selector RasterizationRateMapDescriptor = "rasterizationRateMapDescriptorWithScreenSize:";

    public static readonly Selector ScreenSize = "screenSize";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetLayer = "setLayer:atIndex:";

    public static readonly Selector SetScreenSize = "setScreenSize:";
}
