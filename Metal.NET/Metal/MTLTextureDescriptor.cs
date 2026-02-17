namespace Metal.NET;

public class MTLTextureDescriptor : IDisposable
{
    public MTLTextureDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTextureDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTextureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTextureDescriptor(nint value)
    {
        return new(value);
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTextureDescriptor");

    public static MTLTextureDescriptor New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLTextureDescriptor(ptr);
    }

    public void SetAllowGPUOptimizedContents(Bool8 allowGPUOptimizedContents)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetAllowGPUOptimizedContents, (nint)allowGPUOptimizedContents.Value);
    }

    public void SetArrayLength(uint arrayLength)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetArrayLength, (nint)arrayLength);
    }

    public void SetCompressionType(MTLTextureCompressionType compressionType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetCompressionType, (nint)(uint)compressionType);
    }

    public void SetCpuCacheMode(MTLCPUCacheMode cpuCacheMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetCpuCacheMode, (nint)(uint)cpuCacheMode);
    }

    public void SetDepth(uint depth)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetDepth, (nint)depth);
    }

    public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetHazardTrackingMode, (nint)(uint)hazardTrackingMode);
    }

    public void SetHeight(uint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetHeight, (nint)height);
    }

    public void SetMipmapLevelCount(uint mipmapLevelCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetMipmapLevelCount, (nint)mipmapLevelCount);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetPixelFormat, (nint)(uint)pixelFormat);
    }

    public void SetPlacementSparsePageSize(MTLSparsePageSize placementSparsePageSize)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetPlacementSparsePageSize, (nint)(uint)placementSparsePageSize);
    }

    public void SetResourceOptions(uint resourceOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetResourceOptions, (nint)resourceOptions);
    }

    public void SetSampleCount(uint sampleCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetSampleCount, (nint)sampleCount);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetStorageMode, (nint)(uint)storageMode);
    }

    public void SetSwizzle(MTLTextureSwizzleChannels swizzle)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetSwizzle, swizzle.NativePtr);
    }

    public void SetTextureType(MTLTextureType textureType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetTextureType, (nint)(uint)textureType);
    }

    public void SetUsage(uint usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetUsage, (nint)usage);
    }

    public void SetWidth(uint width)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureDescriptorSelector.SetWidth, (nint)width);
    }

    public static MTLTextureDescriptor Texture2DDescriptor(MTLPixelFormat pixelFormat, uint width, uint height, Bool8 mipmapped)
    {
        MTLTextureDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLTextureDescriptorSelector.Texture2DDescriptorWidthHeightMipmapped, (nint)(uint)pixelFormat, (nint)width, (nint)height, (nint)mipmapped.Value));

        return result;
    }

    public static MTLTextureDescriptor TextureBufferDescriptor(MTLPixelFormat pixelFormat, uint width, uint resourceOptions, uint usage)
    {
        MTLTextureDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLTextureDescriptorSelector.TextureBufferDescriptorWidthResourceOptionsUsage, (nint)(uint)pixelFormat, (nint)width, (nint)resourceOptions, (nint)usage));

        return result;
    }

    public static MTLTextureDescriptor TextureCubeDescriptor(MTLPixelFormat pixelFormat, uint size, Bool8 mipmapped)
    {
        MTLTextureDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLTextureDescriptorSelector.TextureCubeDescriptorSizeMipmapped, (nint)(uint)pixelFormat, (nint)size, (nint)mipmapped.Value));

        return result;
    }

}

file class MTLTextureDescriptorSelector
{
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

    public static readonly Selector Texture2DDescriptorWidthHeightMipmapped = Selector.Register("texture2DDescriptor:width:height:mipmapped:");

    public static readonly Selector TextureBufferDescriptorWidthResourceOptionsUsage = Selector.Register("textureBufferDescriptor:width:resourceOptions:usage:");

    public static readonly Selector TextureCubeDescriptorSizeMipmapped = Selector.Register("textureCubeDescriptor:size:mipmapped:");
}
