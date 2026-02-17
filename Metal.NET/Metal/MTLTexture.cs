namespace Metal.NET;

public class MTLTexture : IDisposable
{
    public MTLTexture(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTexture()
    {
        Release();
    }

    public nint NativePtr { get; }

    public Bool8 AllowGPUOptimizedContents => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.AllowGPUOptimizedContents);

    public nuint ArrayLength => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.ArrayLength);

    public MTLBuffer Buffer => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.Buffer));

    public nuint BufferBytesPerRow => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.BufferBytesPerRow);

    public nuint BufferOffset => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.BufferOffset);

    public MTLTextureCompressionType CompressionType => (MTLTextureCompressionType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureSelector.CompressionType));

    public nuint Depth => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.Depth);

    public nuint FirstMipmapInTail => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.FirstMipmapInTail);

    public Bool8 FramebufferOnly => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.FramebufferOnly);

    public nuint Height => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.Height);

    public nint Iosurface => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.Iosurface);

    public nuint IosurfacePlane => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.IosurfacePlane);

    public Bool8 IsFramebufferOnly => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.IsFramebufferOnly);

    public Bool8 IsShareable => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.IsShareable);

    public Bool8 IsSparse => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.IsSparse);

    public nuint MipmapLevelCount => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.MipmapLevelCount);

    public nuint ParentRelativeLevel => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.ParentRelativeLevel);

    public nuint ParentRelativeSlice => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.ParentRelativeSlice);

    public MTLTexture ParentTexture => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.ParentTexture));

    public MTLPixelFormat PixelFormat => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureSelector.PixelFormat));

    public MTLTexture RemoteStorageTexture => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.RemoteStorageTexture));

    public MTLResource RootResource => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.RootResource));

    public nuint SampleCount => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.SampleCount);

    public Bool8 Shareable => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.Shareable);

    public MTLTextureSparseTier SparseTextureTier => (MTLTextureSparseTier)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureSelector.SparseTextureTier));

    public MTLTextureSwizzleChannels Swizzle => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.Swizzle));

    public nuint TailSizeInBytes => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.TailSizeInBytes);

    public MTLTextureType TextureType => (MTLTextureType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureSelector.TextureType));

    public nuint Usage => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.Usage);

    public nuint Width => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.Width);

    public void GetBytes(int pixelBytes, uint bytesPerRow, uint bytesPerImage, MTLRegion region, uint level, uint slice)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureSelector.GetBytesBytesPerRowBytesPerImageRegionLevelSlice, pixelBytes, (nuint)bytesPerRow, (nuint)bytesPerImage, region, (nuint)level, (nuint)slice);
    }

    public void GetBytes(int pixelBytes, uint bytesPerRow, MTLRegion region, uint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureSelector.GetBytesBytesPerRowRegionLevel, pixelBytes, (nuint)bytesPerRow, region, (nuint)level);
    }

    public MTLTexture NewRemoteTextureViewForDevice(MTLDevice device)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewRemoteTextureViewForDevice, device.NativePtr));

        return result;
    }

    public MTLSharedTextureHandle NewSharedTextureHandle()
    {
        MTLSharedTextureHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewSharedTextureHandle));

        return result;
    }

    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewTextureView, (uint)pixelFormat));

        return result;
    }

    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewTextureViewTextureTypeLevelRangeSliceRange, (uint)pixelFormat, (uint)textureType, levelRange, sliceRange));

        return result;
    }

    public MTLTexture NewTextureView(MTLTextureViewDescriptor descriptor)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewTextureView, descriptor.NativePtr));

        return result;
    }

    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange, MTLTextureSwizzleChannels swizzle)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewTextureViewTextureTypeLevelRangeSliceRangeSwizzle, (uint)pixelFormat, (uint)textureType, levelRange, sliceRange, swizzle.NativePtr));

        return result;
    }

    public void ReplaceRegion(MTLRegion region, uint level, uint slice, int pixelBytes, uint bytesPerRow, uint bytesPerImage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureSelector.ReplaceRegionLevelSlicePixelBytesBytesPerRowBytesPerImage, region, (nuint)level, (nuint)slice, pixelBytes, (nuint)bytesPerRow, (nuint)bytesPerImage);
    }

    public void ReplaceRegion(MTLRegion region, uint level, int pixelBytes, uint bytesPerRow)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureSelector.ReplaceRegionLevelPixelBytesBytesPerRow, region, (nuint)level, pixelBytes, (nuint)bytesPerRow);
    }

    public static implicit operator nint(MTLTexture value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTexture(nint value)
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

}

file class MTLTextureSelector
{
    public static readonly Selector AllowGPUOptimizedContents = Selector.Register("allowGPUOptimizedContents");

    public static readonly Selector ArrayLength = Selector.Register("arrayLength");

    public static readonly Selector Buffer = Selector.Register("buffer");

    public static readonly Selector BufferBytesPerRow = Selector.Register("bufferBytesPerRow");

    public static readonly Selector BufferOffset = Selector.Register("bufferOffset");

    public static readonly Selector CompressionType = Selector.Register("compressionType");

    public static readonly Selector Depth = Selector.Register("depth");

    public static readonly Selector FirstMipmapInTail = Selector.Register("firstMipmapInTail");

    public static readonly Selector FramebufferOnly = Selector.Register("framebufferOnly");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Height = Selector.Register("height");

    public static readonly Selector Iosurface = Selector.Register("iosurface");

    public static readonly Selector IosurfacePlane = Selector.Register("iosurfacePlane");

    public static readonly Selector IsFramebufferOnly = Selector.Register("isFramebufferOnly");

    public static readonly Selector IsShareable = Selector.Register("isShareable");

    public static readonly Selector IsSparse = Selector.Register("isSparse");

    public static readonly Selector MipmapLevelCount = Selector.Register("mipmapLevelCount");

    public static readonly Selector ParentRelativeLevel = Selector.Register("parentRelativeLevel");

    public static readonly Selector ParentRelativeSlice = Selector.Register("parentRelativeSlice");

    public static readonly Selector ParentTexture = Selector.Register("parentTexture");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector RemoteStorageTexture = Selector.Register("remoteStorageTexture");

    public static readonly Selector RootResource = Selector.Register("rootResource");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector Shareable = Selector.Register("shareable");

    public static readonly Selector SparseTextureTier = Selector.Register("sparseTextureTier");

    public static readonly Selector Swizzle = Selector.Register("swizzle");

    public static readonly Selector TailSizeInBytes = Selector.Register("tailSizeInBytes");

    public static readonly Selector TextureType = Selector.Register("textureType");

    public static readonly Selector Usage = Selector.Register("usage");

    public static readonly Selector Width = Selector.Register("width");

    public static readonly Selector GetBytesBytesPerRowBytesPerImageRegionLevelSlice = Selector.Register("getBytes:bytesPerRow:bytesPerImage:region:level:slice:");

    public static readonly Selector GetBytesBytesPerRowRegionLevel = Selector.Register("getBytes:bytesPerRow:region:level:");

    public static readonly Selector NewRemoteTextureViewForDevice = Selector.Register("newRemoteTextureViewForDevice:");

    public static readonly Selector NewSharedTextureHandle = Selector.Register("newSharedTextureHandle");

    public static readonly Selector NewTextureView = Selector.Register("newTextureView:");

    public static readonly Selector NewTextureViewTextureTypeLevelRangeSliceRange = Selector.Register("newTextureView:textureType:levelRange:sliceRange:");

    public static readonly Selector NewTextureViewTextureTypeLevelRangeSliceRangeSwizzle = Selector.Register("newTextureView:textureType:levelRange:sliceRange:swizzle:");

    public static readonly Selector ReplaceRegionLevelSlicePixelBytesBytesPerRowBytesPerImage = Selector.Register("replaceRegion:level:slice:pixelBytes:bytesPerRow:bytesPerImage:");

    public static readonly Selector ReplaceRegionLevelPixelBytesBytesPerRow = Selector.Register("replaceRegion:level:pixelBytes:bytesPerRow:");
}
