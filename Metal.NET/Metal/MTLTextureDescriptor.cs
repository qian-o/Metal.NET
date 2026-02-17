namespace Metal.NET;

public class MTLTextureDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTextureDescriptor");

    public MTLTextureDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLTextureDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLTextureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public Bool8 AllowGPUOptimizedContents
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureDescriptorSelector.AllowGPUOptimizedContents);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetAllowGPUOptimizedContents, value);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorSelector.ArrayLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetArrayLength, value);
    }

    public MTLTextureCompressionType CompressionType
    {
        get => (MTLTextureCompressionType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureDescriptorSelector.CompressionType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetCompressionType, (uint)value);
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureDescriptorSelector.CpuCacheMode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetCpuCacheMode, (uint)value);
    }

    public nuint Depth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorSelector.Depth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetDepth, value);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureDescriptorSelector.HazardTrackingMode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetHazardTrackingMode, (uint)value);
    }

    public nuint Height
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorSelector.Height);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetHeight, value);
    }

    public nuint MipmapLevelCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorSelector.MipmapLevelCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetMipmapLevelCount, value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureDescriptorSelector.PixelFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetPixelFormat, (uint)value);
    }

    public MTLSparsePageSize PlacementSparsePageSize
    {
        get => (MTLSparsePageSize)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureDescriptorSelector.PlacementSparsePageSize));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetPlacementSparsePageSize, (uint)value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureDescriptorSelector.ResourceOptions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetResourceOptions, (uint)value);
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorSelector.SampleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetSampleCount, value);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureDescriptorSelector.StorageMode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetStorageMode, (uint)value);
    }

    public MTLTextureSwizzleChannels Swizzle
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureDescriptorSelector.Swizzle));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetSwizzle, value.NativePtr);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureDescriptorSelector.TextureType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetTextureType, (uint)value);
    }

    public MTLTextureUsage Usage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureDescriptorSelector.Usage));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetUsage, (uint)value);
    }

    public nuint Width
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureDescriptorSelector.Width);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetWidth, value);
    }

    public static implicit operator nint(MTLTextureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTextureDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLTextureDescriptor Texture2DDescriptor(MTLPixelFormat pixelFormat, nuint width, nuint height, Bool8 mipmapped)
    {
        MTLTextureDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLTextureDescriptorSelector.Texture2DDescriptorWidthHeightMipmapped, (uint)pixelFormat, width, height, mipmapped));

        return result;
    }

    public static MTLTextureDescriptor TextureBufferDescriptor(MTLPixelFormat pixelFormat, nuint width, MTLResourceOptions resourceOptions, MTLTextureUsage usage)
    {
        MTLTextureDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLTextureDescriptorSelector.TextureBufferDescriptorWidthResourceOptionsUsage, (uint)pixelFormat, width, (uint)resourceOptions, (uint)usage));

        return result;
    }

    public static MTLTextureDescriptor TextureCubeDescriptor(MTLPixelFormat pixelFormat, nuint size, Bool8 mipmapped)
    {
        MTLTextureDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLTextureDescriptorSelector.TextureCubeDescriptorSizeMipmapped, (uint)pixelFormat, size, mipmapped));

        return result;
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLTextureDescriptorSelector
{
    public static readonly Selector AllowGPUOptimizedContents = Selector.Register("allowGPUOptimizedContents");

    public static readonly Selector SetAllowGPUOptimizedContents = Selector.Register("setAllowGPUOptimizedContents:");

    public static readonly Selector ArrayLength = Selector.Register("arrayLength");

    public static readonly Selector SetArrayLength = Selector.Register("setArrayLength:");

    public static readonly Selector CompressionType = Selector.Register("compressionType");

    public static readonly Selector SetCompressionType = Selector.Register("setCompressionType:");

    public static readonly Selector CpuCacheMode = Selector.Register("cpuCacheMode");

    public static readonly Selector SetCpuCacheMode = Selector.Register("setCpuCacheMode:");

    public static readonly Selector Depth = Selector.Register("depth");

    public static readonly Selector SetDepth = Selector.Register("setDepth:");

    public static readonly Selector HazardTrackingMode = Selector.Register("hazardTrackingMode");

    public static readonly Selector SetHazardTrackingMode = Selector.Register("setHazardTrackingMode:");

    public static readonly Selector Height = Selector.Register("height");

    public static readonly Selector SetHeight = Selector.Register("setHeight:");

    public static readonly Selector MipmapLevelCount = Selector.Register("mipmapLevelCount");

    public static readonly Selector SetMipmapLevelCount = Selector.Register("setMipmapLevelCount:");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");

    public static readonly Selector PlacementSparsePageSize = Selector.Register("placementSparsePageSize");

    public static readonly Selector SetPlacementSparsePageSize = Selector.Register("setPlacementSparsePageSize:");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector SetResourceOptions = Selector.Register("setResourceOptions:");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector SetSampleCount = Selector.Register("setSampleCount:");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector SetStorageMode = Selector.Register("setStorageMode:");

    public static readonly Selector Swizzle = Selector.Register("swizzle");

    public static readonly Selector SetSwizzle = Selector.Register("setSwizzle:");

    public static readonly Selector TextureType = Selector.Register("textureType");

    public static readonly Selector SetTextureType = Selector.Register("setTextureType:");

    public static readonly Selector Usage = Selector.Register("usage");

    public static readonly Selector SetUsage = Selector.Register("setUsage:");

    public static readonly Selector Width = Selector.Register("width");

    public static readonly Selector SetWidth = Selector.Register("setWidth:");

    public static readonly Selector Texture2DDescriptorWidthHeightMipmapped = Selector.Register("texture2DDescriptor:width:height:mipmapped:");

    public static readonly Selector TextureBufferDescriptorWidthResourceOptionsUsage = Selector.Register("textureBufferDescriptor:width:resourceOptions:usage:");

    public static readonly Selector TextureCubeDescriptorSizeMipmapped = Selector.Register("textureCubeDescriptor:size:mipmapped:");
}
