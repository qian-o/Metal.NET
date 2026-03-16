namespace Metal.NET;

/// <summary>An instance that you use to configure new Metal texture instances.</summary>
public class MTLTextureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTextureDescriptor>
{
    #region INativeObject
    public static new MTLTextureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTextureDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTextureDescriptor() : this(ObjectiveC.AllocInit(MTLTextureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Specifying texture attributes - Properties

    /// <summary>The dimension and arrangement of texture image data.</summary>
    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.TextureType);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetTextureType, (nuint)value);
    }

    /// <summary>The size and bit layout of all pixels in the texture.</summary>
    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    /// <summary>The width of the texture image for the base level mipmap, in pixels.</summary>
    public nuint Width
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.Width);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetWidth, value);
    }

    /// <summary>The height of the texture image for the base level mipmap, in pixels.</summary>
    public nuint Height
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.Height);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetHeight, value);
    }

    /// <summary>The depth of the texture image for the base level mipmap, in pixels.</summary>
    public nuint Depth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.Depth);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetDepth, value);
    }

    /// <summary>The number of mipmap levels for this texture.</summary>
    public nuint MipmapLevelCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.MipmapLevelCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetMipmapLevelCount, value);
    }

    /// <summary>The number of samples in each fragment.</summary>
    public nuint SampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.SampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetSampleCount, value);
    }

    /// <summary>The number of array elements for this texture.</summary>
    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.ArrayLength);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetArrayLength, value);
    }

    /// <summary>The behavior of a new memory allocation.</summary>
    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.ResourceOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetResourceOptions, (nuint)value);
    }

    /// <summary>The CPU cache mode used for the CPU mapping of the texture.</summary>
    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.CpuCacheMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetCpuCacheMode, (nuint)value);
    }

    /// <summary>The location and access permissions of the texture.</summary>
    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.StorageMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetStorageMode, (nuint)value);
    }

    /// <summary>The texture’s hazard tracking mode.</summary>
    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.HazardTrackingMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetHazardTrackingMode, (nuint)value);
    }

    /// <summary>A Boolean value indicating whether the GPU is allowed to adjust the texture’s contents to improve GPU performance.</summary>
    public Bool8 AllowGPUOptimizedContents
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureDescriptorBindings.AllowGPUOptimizedContents);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetAllowGPUOptimizedContents, value);
    }

    /// <summary>Options that determine how you can use the texture.</summary>
    public MTLTextureUsage Usage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetUsage, (nuint)value);
    }

    /// <summary>The pattern you want the GPU to apply to pixels when you read or sample pixels from the texture.</summary>
    public MTLTextureSwizzleChannels Swizzle
    {
        get => ObjectiveC.MsgSendMTLTextureSwizzleChannels(NativePtr, MTLTextureDescriptorBindings.Swizzle);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetSwizzle, value);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLTextureCompressionType CompressionType
    {
        get => (MTLTextureCompressionType)ObjectiveC.MsgSendLong(NativePtr, MTLTextureDescriptorBindings.CompressionType);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetCompressionType, (nint)value);
    }

    /// <summary>Determines the page size for a placement sparse texture.</summary>
    public MTLSparsePageSize PlacementSparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveC.MsgSendLong(NativePtr, MTLTextureDescriptorBindings.PlacementSparsePageSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetPlacementSparsePageSize, (nint)value);
    }
    #endregion

    #region Creating texture descriptors - Methods

    /// <summary>Creates a texture descriptor object for a 2D texture.</summary>
    public static MTLTextureDescriptor Texture2DDescriptor(MTLPixelFormat pixelFormat, nuint width, nuint height, bool mipmapped)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.Texture2DDescriptor, (nuint)pixelFormat, width, height, mipmapped);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a texture descriptor object for a cube texture.</summary>
    public static MTLTextureDescriptor TextureCubeDescriptor(MTLPixelFormat pixelFormat, nuint size, bool mipmapped)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.TextureCubeDescriptor, (nuint)pixelFormat, size, mipmapped);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a texture descriptor object for a texture buffer.</summary>
    public static MTLTextureDescriptor TextureBufferDescriptor(MTLPixelFormat pixelFormat, nuint width, MTLResourceOptions resourceOptions, MTLTextureUsage usage)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.TextureBufferDescriptor, (nuint)pixelFormat, width, (nuint)resourceOptions, (nuint)usage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
}

file static class MTLTextureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTextureDescriptor");

    public static readonly Selector AllowGPUOptimizedContents = "allowGPUOptimizedContents";

    public static readonly Selector ArrayLength = "arrayLength";

    public static readonly Selector CompressionType = "compressionType";

    public static readonly Selector CpuCacheMode = "cpuCacheMode";

    public static readonly Selector Depth = "depth";

    public static readonly Selector HazardTrackingMode = "hazardTrackingMode";

    public static readonly Selector Height = "height";

    public static readonly Selector MipmapLevelCount = "mipmapLevelCount";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector PlacementSparsePageSize = "placementSparsePageSize";

    public static readonly Selector ResourceOptions = "resourceOptions";

    public static readonly Selector SampleCount = "sampleCount";

    public static readonly Selector SetAllowGPUOptimizedContents = "setAllowGPUOptimizedContents:";

    public static readonly Selector SetArrayLength = "setArrayLength:";

    public static readonly Selector SetCompressionType = "setCompressionType:";

    public static readonly Selector SetCpuCacheMode = "setCpuCacheMode:";

    public static readonly Selector SetDepth = "setDepth:";

    public static readonly Selector SetHazardTrackingMode = "setHazardTrackingMode:";

    public static readonly Selector SetHeight = "setHeight:";

    public static readonly Selector SetMipmapLevelCount = "setMipmapLevelCount:";

    public static readonly Selector SetPixelFormat = "setPixelFormat:";

    public static readonly Selector SetPlacementSparsePageSize = "setPlacementSparsePageSize:";

    public static readonly Selector SetResourceOptions = "setResourceOptions:";

    public static readonly Selector SetSampleCount = "setSampleCount:";

    public static readonly Selector SetStorageMode = "setStorageMode:";

    public static readonly Selector SetSwizzle = "setSwizzle:";

    public static readonly Selector SetTextureType = "setTextureType:";

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector SetWidth = "setWidth:";

    public static readonly Selector StorageMode = "storageMode";

    public static readonly Selector Swizzle = "swizzle";

    public static readonly Selector Texture2DDescriptor = "texture2DDescriptorWithPixelFormat:width:height:mipmapped:";

    public static readonly Selector TextureBufferDescriptor = "textureBufferDescriptorWithPixelFormat:width:resourceOptions:usage:";

    public static readonly Selector TextureCubeDescriptor = "textureCubeDescriptorWithPixelFormat:size:mipmapped:";

    public static readonly Selector TextureType = "textureType";

    public static readonly Selector Usage = "usage";

    public static readonly Selector Width = "width";
}
