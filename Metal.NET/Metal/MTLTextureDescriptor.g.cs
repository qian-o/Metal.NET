namespace Metal.NET;

file class MTLTextureDescriptorSelector
{
    public static readonly Selector SetAllowGPUOptimizedContents_ = Selector.Register("setAllowGPUOptimizedContents:");
    public static readonly Selector SetArrayLength_ = Selector.Register("setArrayLength:");
    public static readonly Selector SetCompressionType_ = Selector.Register("setCompressionType:");
    public static readonly Selector SetCpuCacheMode_ = Selector.Register("setCpuCacheMode:");
    public static readonly Selector SetDepth_ = Selector.Register("setDepth:");
    public static readonly Selector SetHazardTrackingMode_ = Selector.Register("setHazardTrackingMode:");
    public static readonly Selector SetHeight_ = Selector.Register("setHeight:");
    public static readonly Selector SetMipmapLevelCount_ = Selector.Register("setMipmapLevelCount:");
    public static readonly Selector SetPixelFormat_ = Selector.Register("setPixelFormat:");
    public static readonly Selector SetPlacementSparsePageSize_ = Selector.Register("setPlacementSparsePageSize:");
    public static readonly Selector SetResourceOptions_ = Selector.Register("setResourceOptions:");
    public static readonly Selector SetSampleCount_ = Selector.Register("setSampleCount:");
    public static readonly Selector SetStorageMode_ = Selector.Register("setStorageMode:");
    public static readonly Selector SetSwizzle_ = Selector.Register("setSwizzle:");
    public static readonly Selector SetTextureType_ = Selector.Register("setTextureType:");
    public static readonly Selector SetUsage_ = Selector.Register("setUsage:");
    public static readonly Selector SetWidth_ = Selector.Register("setWidth:");
    public static readonly Selector Texture2DDescriptor_width_height_mipmapped_ = Selector.Register("texture2DDescriptor:width:height:mipmapped:");
    public static readonly Selector TextureBufferDescriptor_width_resourceOptions_usage_ = Selector.Register("textureBufferDescriptor:width:resourceOptions:usage:");
    public static readonly Selector TextureCubeDescriptor_size_mipmapped_ = Selector.Register("textureCubeDescriptor:size:mipmapped:");
}

public class MTLTextureDescriptor : IDisposable
{
    public MTLTextureDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLTextureDescriptor(ptr);
    }

    public void SetAllowGPUOptimizedContents(Bool8 allowGPUOptimizedContents)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetAllowGPUOptimizedContents_, (nint)allowGPUOptimizedContents.Value);
    }

    public void SetArrayLength(nuint arrayLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetArrayLength_, (nint)arrayLength);
    }

    public void SetCompressionType(MTLTextureCompressionType compressionType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetCompressionType_, (nint)(uint)compressionType);
    }

    public void SetCpuCacheMode(MTLCPUCacheMode cpuCacheMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetCpuCacheMode_, (nint)(uint)cpuCacheMode);
    }

    public void SetDepth(nuint depth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetDepth_, (nint)depth);
    }

    public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetHazardTrackingMode_, (nint)(uint)hazardTrackingMode);
    }

    public void SetHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetHeight_, (nint)height);
    }

    public void SetMipmapLevelCount(nuint mipmapLevelCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetMipmapLevelCount_, (nint)mipmapLevelCount);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetPixelFormat_, (nint)(uint)pixelFormat);
    }

    public void SetPlacementSparsePageSize(MTLSparsePageSize placementSparsePageSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetPlacementSparsePageSize_, (nint)(uint)placementSparsePageSize);
    }

    public void SetResourceOptions(nuint resourceOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetResourceOptions_, (nint)resourceOptions);
    }

    public void SetSampleCount(nuint sampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetSampleCount_, (nint)sampleCount);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetStorageMode_, (nint)(uint)storageMode);
    }

    public void SetSwizzle(MTLTextureSwizzleChannels swizzle)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetSwizzle_, swizzle.NativePtr);
    }

    public void SetTextureType(MTLTextureType textureType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetTextureType_, (nint)(uint)textureType);
    }

    public void SetUsage(nuint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetUsage_, (nint)usage);
    }

    public void SetWidth(nuint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureDescriptorSelector.SetWidth_, (nint)width);
    }

    public static MTLTextureDescriptor Texture2DDescriptor(MTLPixelFormat pixelFormat, nuint width, nuint height, Bool8 mipmapped)
    {
        var result = new MTLTextureDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLTextureDescriptorSelector.Texture2DDescriptor_width_height_mipmapped_, (nint)(uint)pixelFormat, (nint)width, (nint)height, (nint)mipmapped.Value));

        return result;
    }

    public static MTLTextureDescriptor TextureBufferDescriptor(MTLPixelFormat pixelFormat, nuint width, nuint resourceOptions, nuint usage)
    {
        var result = new MTLTextureDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLTextureDescriptorSelector.TextureBufferDescriptor_width_resourceOptions_usage_, (nint)(uint)pixelFormat, (nint)width, (nint)resourceOptions, (nint)usage));

        return result;
    }

    public static MTLTextureDescriptor TextureCubeDescriptor(MTLPixelFormat pixelFormat, nuint size, Bool8 mipmapped)
    {
        var result = new MTLTextureDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLTextureDescriptorSelector.TextureCubeDescriptor_size_mipmapped_, (nint)(uint)pixelFormat, (nint)size, (nint)mipmapped.Value));

        return result;
    }

}
