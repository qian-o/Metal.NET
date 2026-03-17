namespace Metal.NET;

/// <summary>
/// An object that you use to configure a texture sampler.
/// </summary>
public class MTLSamplerDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLSamplerDescriptor>
{
    #region INativeObject
    public static new MTLSamplerDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLSamplerDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLSamplerDescriptor() : this(ObjectiveC.AllocInit(MTLSamplerDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Declaring the coordinate space - Properties

    /// <summary>
    /// A Boolean value that indicates whether texture coordinates are normalized to the range [0.0, 1.0].
    /// </summary>
    public Bool8 NormalizedCoordinates
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.NormalizedCoordinates);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetNormalizedCoordinates, value);
    }
    #endregion

    #region Declaring addressing modes - Properties

    /// <summary>
    /// The address mode for the texture depth (r) coordinate.
    /// </summary>
    public MTLSamplerAddressMode RAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.RAddressMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetRAddressMode, (nuint)value);
    }

    /// <summary>
    /// The address mode for the texture width (s) coordinate.
    /// </summary>
    public MTLSamplerAddressMode SAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.SAddressMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetSAddressMode, (nuint)value);
    }

    /// <summary>
    /// The address mode for the texture height (t) coordinate.
    /// </summary>
    public MTLSamplerAddressMode TAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.TAddressMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetTAddressMode, (nuint)value);
    }

    /// <summary>
    /// The border color for clamped texture values.
    /// </summary>
    public MTLSamplerBorderColor BorderColor
    {
        get => (MTLSamplerBorderColor)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.BorderColor);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetBorderColor, (nuint)value);
    }
    #endregion

    #region Declaring filter modes - Properties

    /// <summary>
    /// The filtering option for combining pixels within one mipmap level when the sample footprint is larger than a pixel (minification).
    /// </summary>
    public MTLSamplerMinMagFilter MinFilter
    {
        get => (MTLSamplerMinMagFilter)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.MinFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMinFilter, (nuint)value);
    }

    /// <summary>
    /// The filtering operation for combining pixels within one mipmap level when the sample footprint is smaller than a pixel (magnification).
    /// </summary>
    public MTLSamplerMinMagFilter MagFilter
    {
        get => (MTLSamplerMinMagFilter)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.MagFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMagFilter, (nuint)value);
    }

    /// <summary>
    /// The filtering option for combining pixels between two mipmap levels.
    /// </summary>
    public MTLSamplerMipFilter MipFilter
    {
        get => (MTLSamplerMipFilter)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.MipFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMipFilter, (nuint)value);
    }

    /// <summary>
    /// The minimum level of detail (LOD) to use when sampling from a texture.
    /// </summary>
    public float LodMinClamp
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodMinClamp);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodMinClamp, value);
    }

    /// <summary>
    /// The maximum level of detail (LOD) to use when sampling from a texture.
    /// </summary>
    public float LodMaxClamp
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodMaxClamp);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodMaxClamp, value);
    }

    /// <summary>
    /// A Boolean value that specifies whether the GPU can use an average level of detail (LOD) when sampling from a texture.
    /// </summary>
    public Bool8 LodAverage
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.LodAverage);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodAverage, value);
    }

    /// <summary>
    /// The number of samples that can be taken to improve the quality of sample footprints that are anisotropic.
    /// </summary>
    public nuint MaxAnisotropy
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.MaxAnisotropy);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMaxAnisotropy, value);
    }
    #endregion

    #region Declaring the depth comparison mode - Properties

    /// <summary>
    /// The sampler comparison function used when performing a sample compare operation on a depth texture.
    /// </summary>
    public MTLCompareFunction CompareFunction
    {
        get => (MTLCompareFunction)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.CompareFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetCompareFunction, (nuint)value);
    }
    #endregion

    #region Declaring whether the sampler can be used in argument buffers - Properties

    /// <summary>
    /// A Boolean value that indicates whether you can reference a sampler, that you make with this descriptor, by its resource ID from an argument buffer.
    /// </summary>
    public Bool8 SupportArgumentBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.SupportArgumentBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetSupportArgumentBuffers, value);
    }
    #endregion

    #region Identifying the sampler - Properties

    /// <summary>
    /// A string that identifies the sampler.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLSamplerDescriptorBindings.Label);
        set => SetProperty(ref field, MTLSamplerDescriptorBindings.SetLabel, value);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// Sets the level-of-detail (lod) bias when sampling from a texture.
    /// </summary>
    public float LodBias
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodBias);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodBias, value);
    }

    /// <summary>
    /// Sets the reduction mode for filtering contributing samples.
    /// </summary>
    public MTLSamplerReductionMode ReductionMode
    {
        get => (MTLSamplerReductionMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.ReductionMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetReductionMode, (nuint)value);
    }
    #endregion
}

file static class MTLSamplerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLSamplerDescriptor");

    public static readonly Selector BorderColor = "borderColor";

    public static readonly Selector CompareFunction = "compareFunction";

    public static readonly Selector Label = "label";

    public static readonly Selector LodAverage = "lodAverage";

    public static readonly Selector LodBias = "lodBias";

    public static readonly Selector LodMaxClamp = "lodMaxClamp";

    public static readonly Selector LodMinClamp = "lodMinClamp";

    public static readonly Selector MagFilter = "magFilter";

    public static readonly Selector MaxAnisotropy = "maxAnisotropy";

    public static readonly Selector MinFilter = "minFilter";

    public static readonly Selector MipFilter = "mipFilter";

    public static readonly Selector NormalizedCoordinates = "normalizedCoordinates";

    public static readonly Selector RAddressMode = "rAddressMode";

    public static readonly Selector ReductionMode = "reductionMode";

    public static readonly Selector SAddressMode = "sAddressMode";

    public static readonly Selector SetBorderColor = "setBorderColor:";

    public static readonly Selector SetCompareFunction = "setCompareFunction:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetLodAverage = "setLodAverage:";

    public static readonly Selector SetLodBias = "setLodBias:";

    public static readonly Selector SetLodMaxClamp = "setLodMaxClamp:";

    public static readonly Selector SetLodMinClamp = "setLodMinClamp:";

    public static readonly Selector SetMagFilter = "setMagFilter:";

    public static readonly Selector SetMaxAnisotropy = "setMaxAnisotropy:";

    public static readonly Selector SetMinFilter = "setMinFilter:";

    public static readonly Selector SetMipFilter = "setMipFilter:";

    public static readonly Selector SetNormalizedCoordinates = "setNormalizedCoordinates:";

    public static readonly Selector SetRAddressMode = "setRAddressMode:";

    public static readonly Selector SetReductionMode = "setReductionMode:";

    public static readonly Selector SetSAddressMode = "setSAddressMode:";

    public static readonly Selector SetSupportArgumentBuffers = "setSupportArgumentBuffers:";

    public static readonly Selector SetTAddressMode = "setTAddressMode:";

    public static readonly Selector SupportArgumentBuffers = "supportArgumentBuffers";

    public static readonly Selector TAddressMode = "tAddressMode";
}
