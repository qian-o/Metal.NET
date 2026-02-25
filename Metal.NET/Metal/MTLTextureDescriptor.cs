namespace Metal.NET;

public class MTLTextureDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLTextureDescriptor>
{
    public static MTLTextureDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTLTextureDescriptor Null => Create(0, false);
    public static MTLTextureDescriptor Empty => Null;

    public MTLTextureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLTextureDescriptorBindings.Class), true)
    {
    }

    public Bool8 AllowGPUOptimizedContents
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureDescriptorBindings.AllowGPUOptimizedContents);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorBindings.SetAllowGPUOptimizedContents, value);
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

    public static MTLTextureDescriptor Texture2DDescriptor(MTLPixelFormat pixelFormat, nuint width, nuint height, bool mipmapped)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.Texture2DDescriptor, (nuint)pixelFormat, width, height, (Bool8)mipmapped);

        return new(nativePtr, false);
    }

    public static MTLTextureDescriptor TextureBufferDescriptor(MTLPixelFormat pixelFormat, nuint width, MTLResourceOptions resourceOptions, MTLTextureUsage usage)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.TextureBufferDescriptor, (nuint)pixelFormat, width, (nuint)resourceOptions, (nuint)usage);

        return new(nativePtr, false);
    }

    public static MTLTextureDescriptor TextureCubeDescriptor(MTLPixelFormat pixelFormat, nuint size, bool mipmapped)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLTextureDescriptorBindings.Class, MTLTextureDescriptorBindings.TextureCubeDescriptor, (nuint)pixelFormat, size, (Bool8)mipmapped);

        return new(nativePtr, false);
    }
}

file static class MTLTextureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTextureDescriptor");

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
