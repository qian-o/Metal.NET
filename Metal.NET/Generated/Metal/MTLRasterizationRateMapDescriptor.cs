namespace Metal.NET;

public partial class MTLRasterizationRateMapDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRasterizationRateMapDescriptor>
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

    public MTLRasterizationRateLayerArray Layers
    {
        get => GetProperty(ref field, MTLRasterizationRateMapDescriptorBindings.Layers);
    }

    public MTLSize ScreenSize
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapDescriptorBindings.ScreenSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorBindings.SetScreenSize, value);
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

    public MTLRasterizationRateLayerDescriptor Layer(nuint layerIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRasterizationRateMapDescriptorBindings.LayerAtIndex, layerIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorBindings.SetLayer_AtIndex, layer.NativePtr, layerIndex);
    }

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptorWithScreenSize(MTLSize screenSize)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLRasterizationRateMapDescriptorBindings.Class, MTLRasterizationRateMapDescriptorBindings.RasterizationRateMapDescriptorWithScreenSize, screenSize);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptorWithScreenSize(MTLSize screenSize, MTLRasterizationRateLayerDescriptor layer)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLRasterizationRateMapDescriptorBindings.Class, MTLRasterizationRateMapDescriptorBindings.RasterizationRateMapDescriptorWithScreenSize_Layer, screenSize, layer.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLRasterizationRateMapDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRasterizationRateMapDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector LayerAtIndex = "layerAtIndex:";

    public static readonly Selector LayerCount = "layerCount";

    public static readonly Selector Layers = "layers";

    public static readonly Selector RasterizationRateMapDescriptorWithScreenSize = "rasterizationRateMapDescriptorWithScreenSize:";

    public static readonly Selector RasterizationRateMapDescriptorWithScreenSize_Layer = "rasterizationRateMapDescriptorWithScreenSize:layer:";

    public static readonly Selector ScreenSize = "screenSize";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetLayer_AtIndex = "setLayer:atIndex:";

    public static readonly Selector SetScreenSize = "setScreenSize:";
}
