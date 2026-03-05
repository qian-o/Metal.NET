namespace Metal.NET;

public class MTLRasterizationRateMapDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRasterizationRateMapDescriptor>
{
    #region INativeObject
    public static new MTLRasterizationRateMapDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRasterizationRateMapDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRasterizationRateMapDescriptor() : this(ObjectiveC.AllocInit(MTLRasterizationRateMapDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLRasterizationRateMapDescriptorBindings.Label);
        set => SetProperty(ref field, MTLRasterizationRateMapDescriptorBindings.SetLabel, value);
    }

    public nuint LayerCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRasterizationRateMapDescriptorBindings.LayerCount);
    }

    public MTLRasterizationRateLayerArray Layers
    {
        get => GetProperty(ref field, MTLRasterizationRateMapDescriptorBindings.Layers);
    }

    public MTLSize ScreenSize
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapDescriptorBindings.ScreenSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorBindings.SetScreenSize, value);
    }

    public MTLRasterizationRateLayerDescriptor Layer(nuint layerIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLRasterizationRateMapDescriptorBindings.Layer, layerIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(MTLRasterizationRateMapDescriptorBindings.Class, MTLRasterizationRateMapDescriptorBindings.RasterizationRateMapDescriptor, screenSize);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize, MTLRasterizationRateLayerDescriptor layer)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(MTLRasterizationRateMapDescriptorBindings.Class, MTLRasterizationRateMapDescriptorBindings.RasterizationRateMapDescriptorWithScreenSizelayer, screenSize, layer.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorBindings.SetLayer, layer.NativePtr, layerIndex);
    }
}

file static class MTLRasterizationRateMapDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRasterizationRateMapDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector Layer = "layerAtIndex:";

    public static readonly Selector LayerCount = "layerCount";

    public static readonly Selector Layers = "layers";

    public static readonly Selector RasterizationRateMapDescriptor = "rasterizationRateMapDescriptorWithScreenSize:";

    public static readonly Selector RasterizationRateMapDescriptorWithScreenSizelayer = "rasterizationRateMapDescriptorWithScreenSize:layer:";

    public static readonly Selector ScreenSize = "screenSize";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetLayer = "setLayer:atIndex:";

    public static readonly Selector SetScreenSize = "setScreenSize:";
}
