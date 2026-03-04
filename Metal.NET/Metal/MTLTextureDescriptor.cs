namespace Metal.NET;

public class MTLTextureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLTextureDescriptor>
{
    public static MTLTextureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLTextureDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLTextureDescriptor() : this(ObjectiveC.AllocInit(MTLTextureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public Bool8 AllowGPUOptimizedContents
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureDescriptorBindings.AllowGPUOptimizedContents);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetAllowGPUOptimizedContents, value);
    }

    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.ArrayLength);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetArrayLength, value);
    }

    public MTLTextureCompressionType CompressionType
    {
        get => (MTLTextureCompressionType)ObjectiveC.MsgSendLong(NativePtr, MTLTextureDescriptorBindings.CompressionType);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetCompressionType, (nint)value);
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.CpuCacheMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetCpuCacheMode, (nuint)value);
    }

    public nuint Depth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.Depth);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetDepth, value);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.HazardTrackingMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetHazardTrackingMode, (nuint)value);
    }

    public nuint Height
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.Height);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetHeight, value);
    }

    public nuint MipmapLevelCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.MipmapLevelCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetMipmapLevelCount, value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    public MTLSparsePageSize PlacementSparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveC.MsgSendLong(NativePtr, MTLTextureDescriptorBindings.PlacementSparsePageSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetPlacementSparsePageSize, (nint)value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.ResourceOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetResourceOptions, (nuint)value);
    }

    public nuint SampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.SampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetSampleCount, value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.StorageMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetStorageMode, (nuint)value);
    }

    public MTLTextureSwizzleChannels Swizzle
    {
        get => ObjectiveC.MsgSendMTLTextureSwizzleChannels(NativePtr, MTLTextureDescriptorBindings.Swizzle);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetSwizzle, value);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.TextureType);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetTextureType, (nuint)value);
    }

    public MTLTextureUsage Usage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLTextureDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetUsage, (nuint)value);
    }

    public nuint Width
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.Width);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetWidth, value);
    }

    public static MTLTextureDescriptor Texture2DDescriptor(MTLPixelFormat pixelFormat, nuint width, nuint height, bool mipmapped)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.Texture2DDescriptor, (nuint)pixelFormat, width, height, (Bool8)mipmapped);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static MTLTextureDescriptor TextureBufferDescriptor(MTLPixelFormat pixelFormat, nuint width, MTLResourceOptions resourceOptions, MTLTextureUsage usage)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.TextureBufferDescriptor, (nuint)pixelFormat, width, (nuint)resourceOptions, (nuint)usage);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static MTLTextureDescriptor TextureCubeDescriptor(MTLPixelFormat pixelFormat, nuint size, bool mipmapped)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.TextureCubeDescriptor, (nuint)pixelFormat, size, (Bool8)mipmapped);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
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
