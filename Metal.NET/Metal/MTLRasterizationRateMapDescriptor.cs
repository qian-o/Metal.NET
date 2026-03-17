namespace Metal.NET;

/// <summary>
/// An object that you use to configure new rasterization rate maps.
/// </summary>
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

    #region Identifying the rate map - Properties

    /// <summary>
    /// A string used to identify the rate map you create with the descriptor.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLRasterizationRateMapDescriptorBindings.Label);
        set => SetProperty(ref field, MTLRasterizationRateMapDescriptorBindings.SetLabel, value);
    }
    #endregion

    #region Configuring the viewport size - Properties

    /// <summary>
    /// The size of the viewport coordinate system, in logical pixels.
    /// </summary>
    public MTLSize ScreenSize
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLRasterizationRateMapDescriptorBindings.ScreenSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorBindings.SetScreenSize, value);
    }
    #endregion

    #region Configuring the rate map layers - Properties

    /// <summary>
    /// The number of layers in the rate map.
    /// </summary>
    public nuint LayerCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRasterizationRateMapDescriptorBindings.LayerCount);
    }

    /// <summary>
    /// The rasterization rates for one or more layers in the rate map.
    /// </summary>
    public MTLRasterizationRateLayerArray Layers
    {
        get => GetProperty(ref field, MTLRasterizationRateMapDescriptorBindings.Layers);
    }
    #endregion

    #region Configuring the rate map layers - Methods

    /// <summary>
    /// Returns the layer description for a layer in the rate map.
    /// </summary>
    public MTLRasterizationRateLayerDescriptor Layer(nuint layerIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRasterizationRateMapDescriptorBindings.Layer, layerIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Sets a configuration for a layer rate map.
    /// </summary>
    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateMapDescriptorBindings.SetLayer, layer.NativePtr, layerIndex);
    }
    #endregion

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLRasterizationRateMapDescriptorBindings.Class, MTLRasterizationRateMapDescriptorBindings.RasterizationRateMapDescriptor, screenSize);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize, MTLRasterizationRateLayerDescriptor layer)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLRasterizationRateMapDescriptorBindings.Class, MTLRasterizationRateMapDescriptorBindings.RasterizationRateMapDescriptorWithScreenSizelayer, screenSize, layer.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
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
