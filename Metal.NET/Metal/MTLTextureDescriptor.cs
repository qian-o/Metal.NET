namespace Metal.NET;

public readonly struct MTLTextureDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLTextureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLTextureDescriptorBindings.Class))
    {
    }

    public bool AllowGPUOptimizedContents
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureDescriptorBindings.AllowGPUOptimizedContents);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetAllowGPUOptimizedContents, (Bool8)value);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.ArrayLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetArrayLength, value);
    }

    public MTLTextureCompressionType CompressionType
    {
        get => (MTLTextureCompressionType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureDescriptorBindings.CompressionType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetCompressionType, (nint)value);
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.CpuCacheMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetCpuCacheMode, (nuint)value);
    }

    public nuint Depth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.Depth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetDepth, value);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.HazardTrackingMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetHazardTrackingMode, (nuint)value);
    }

    public nuint Height
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.Height);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetHeight, value);
    }

    public nuint MipmapLevelCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.MipmapLevelCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetMipmapLevelCount, value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.PixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    public MTLSparsePageSize PlacementSparsePageSize
    {
        get => (MTLSparsePageSize)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureDescriptorBindings.PlacementSparsePageSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetPlacementSparsePageSize, (nint)value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.ResourceOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetResourceOptions, (nuint)value);
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.SampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetSampleCount, value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.StorageMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetStorageMode, (nuint)value);
    }

    public MTLTextureSwizzleChannels Swizzle
    {
        get => ObjectiveCRuntime.MsgSendMTLTextureSwizzleChannels(NativePtr, MTLTextureDescriptorBindings.Swizzle);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetSwizzle, value);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.TextureType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetTextureType, (nuint)value);
    }

    public MTLTextureUsage Usage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.Usage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetUsage, (nuint)value);
    }

    public nuint Width
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorBindings.Width);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetWidth, value);
    }

    public static MTLTextureDescriptor? Texture2DDescriptor(MTLPixelFormat pixelFormat, nuint width, nuint height, bool mipmapped)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.Texture2DDescriptor, (nuint)pixelFormat, width, height, (Bool8)mipmapped);
        return ptr is not 0 ? new MTLTextureDescriptor(ptr) : default;
    }

    public static MTLTextureDescriptor? TextureBufferDescriptor(MTLPixelFormat pixelFormat, nuint width, MTLResourceOptions resourceOptions, MTLTextureUsage usage)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.TextureBufferDescriptor, (nuint)pixelFormat, width, (nuint)resourceOptions, (nuint)usage);
        return ptr is not 0 ? new MTLTextureDescriptor(ptr) : default;
    }

    public static MTLTextureDescriptor? TextureCubeDescriptor(MTLPixelFormat pixelFormat, nuint size, bool mipmapped)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.TextureCubeDescriptor, (nuint)pixelFormat, size, (Bool8)mipmapped);
        return ptr is not 0 ? new MTLTextureDescriptor(ptr) : default;
    }
}

file static class MTLTextureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTextureDescriptor");

    public static readonly Selector AllowGPUOptimizedContents = Selector.Register("allowGPUOptimizedContents");

    public static readonly Selector ArrayLength = Selector.Register("arrayLength");

    public static readonly Selector CompressionType = Selector.Register("compressionType");

    public static readonly Selector CpuCacheMode = Selector.Register("cpuCacheMode");

    public static readonly Selector Depth = Selector.Register("depth");

    public static readonly Selector HazardTrackingMode = Selector.Register("hazardTrackingMode");

    public static readonly Selector Height = Selector.Register("height");

    public static readonly Selector MipmapLevelCount = Selector.Register("mipmapLevelCount");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector PlacementSparsePageSize = Selector.Register("placementSparsePageSize");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector SetAllowGPUOptimizedContents = Selector.Register("setAllowGPUOptimizedContents:");

    public static readonly Selector SetArrayLength = Selector.Register("setArrayLength:");

    public static readonly Selector SetCompressionType = Selector.Register("setCompressionType:");

    public static readonly Selector SetCpuCacheMode = Selector.Register("setCpuCacheMode:");

    public static readonly Selector SetDepth = Selector.Register("setDepth:");

    public static readonly Selector SetHazardTrackingMode = Selector.Register("setHazardTrackingMode:");

    public static readonly Selector SetHeight = Selector.Register("setHeight:");

    public static readonly Selector SetMipmapLevelCount = Selector.Register("setMipmapLevelCount:");

    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");

    public static readonly Selector SetPlacementSparsePageSize = Selector.Register("setPlacementSparsePageSize:");

    public static readonly Selector SetResourceOptions = Selector.Register("setResourceOptions:");

    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");

    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");

    public static readonly Selector SetSwizzle = Selector.Register("setSwizzle:");

    public static readonly Selector SetTextureType = Selector.Register("setTextureType:");

    public static readonly Selector SetUsage = Selector.Register("setUsage:");

    public static readonly Selector SetWidth = Selector.Register("setWidth:");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector Swizzle = Selector.Register("swizzle");

    public static readonly Selector Texture2DDescriptor = Selector.Register("texture2DDescriptorWithPixelFormat:width:height:mipmapped:");

    public static readonly Selector TextureBufferDescriptor = Selector.Register("textureBufferDescriptorWithPixelFormat:width:resourceOptions:usage:");

    public static readonly Selector TextureCubeDescriptor = Selector.Register("textureCubeDescriptorWithPixelFormat:size:mipmapped:");

    public static readonly Selector TextureType = Selector.Register("textureType");

    public static readonly Selector Usage = Selector.Register("usage");

    public static readonly Selector Width = Selector.Register("width");
}
