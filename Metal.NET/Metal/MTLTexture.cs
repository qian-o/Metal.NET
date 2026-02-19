namespace Metal.NET;

public readonly struct MTLTexture(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public bool AllowGPUOptimizedContents
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindings.AllowGPUOptimizedContents);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.ArrayLength);
    }

    public MTLBuffer? Buffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.Buffer);
            return ptr is not 0 ? new MTLBuffer(ptr) : default;
        }
    }

    public nuint BufferBytesPerRow
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.BufferBytesPerRow);
    }

    public nuint BufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.BufferOffset);
    }

    public MTLTextureCompressionType CompressionType
    {
        get => (MTLTextureCompressionType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.CompressionType);
    }

    public nuint Depth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.Depth);
    }

    public nuint FirstMipmapInTail
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.FirstMipmapInTail);
    }

    public bool FramebufferOnly
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindings.FramebufferOnly);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureBindings.GpuResourceID);
    }

    public nuint Height
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.Height);
    }

    public nint Iosurface
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.Iosurface);
    }

    public nuint IosurfacePlane
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.IosurfacePlane);
    }

    public bool IsFramebufferOnly
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindings.IsFramebufferOnly);
    }

    public bool IsShareable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindings.IsShareable);
    }

    public bool IsSparse
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindings.IsSparse);
    }

    public nuint MipmapLevelCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.MipmapLevelCount);
    }

    public MTLSharedTextureHandle? NewSharedTextureHandle
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewSharedTextureHandle);
            return ptr is not 0 ? new MTLSharedTextureHandle(ptr) : default;
        }
    }

    public nuint ParentRelativeLevel
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.ParentRelativeLevel);
    }

    public nuint ParentRelativeSlice
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.ParentRelativeSlice);
    }

    public MTLTexture? ParentTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.ParentTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.PixelFormat);
    }

    public MTLTexture? RemoteStorageTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.RemoteStorageTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
    }

    public MTLResource? RootResource
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.RootResource);
            return ptr is not 0 ? new MTLResource(ptr) : default;
        }
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.SampleCount);
    }

    public bool Shareable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindings.Shareable);
    }

    public MTLTextureSparseTier SparseTextureTier
    {
        get => (MTLTextureSparseTier)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.SparseTextureTier);
    }

    public MTLTextureSwizzleChannels Swizzle
    {
        get => ObjectiveCRuntime.MsgSendMTLTextureSwizzleChannels(NativePtr, MTLTextureBindings.Swizzle);
    }

    public nuint TailSizeInBytes
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.TailSizeInBytes);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.TextureType);
    }

    public MTLTextureUsage Usage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.Usage);
    }

    public nuint Width
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.Width);
    }

    public void GetBytes(nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage, MTLRegion region, nuint level, nuint slice)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureBindings.GetBytes, pixelBytes, bytesPerRow, bytesPerImage, region, level, slice);
    }

    public void GetBytes(nint pixelBytes, nuint bytesPerRow, MTLRegion region, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureBindings.GetBytes, pixelBytes, bytesPerRow, region, level);
    }

    public MTLTexture? NewRemoteTextureViewForDevice(MTLDevice device)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewRemoteTextureViewForDevice, device.NativePtr);
        return ptr is not 0 ? new MTLTexture(ptr) : default;
    }

    public MTLTexture? NewTextureView(MTLPixelFormat pixelFormat)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureView, (nuint)pixelFormat);
        return ptr is not 0 ? new MTLTexture(ptr) : default;
    }

    public MTLTexture? NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureView, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange);
        return ptr is not 0 ? new MTLTexture(ptr) : default;
    }

    public MTLTexture? NewTextureView(MTLTextureViewDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureView, descriptor.NativePtr);
        return ptr is not 0 ? new MTLTexture(ptr) : default;
    }

    public MTLTexture? NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange, MTLTextureSwizzleChannels swizzle)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureView, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange, swizzle);
        return ptr is not 0 ? new MTLTexture(ptr) : default;
    }

    public void ReplaceRegion(MTLRegion region, nuint level, nuint slice, nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureBindings.ReplaceRegion, region, level, slice, pixelBytes, bytesPerRow, bytesPerImage);
    }

    public void ReplaceRegion(MTLRegion region, nuint level, nint pixelBytes, nuint bytesPerRow)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureBindings.ReplaceRegion, region, level, pixelBytes, bytesPerRow);
    }
}

file static class MTLTextureBindings
{
    public static readonly Selector AllowGPUOptimizedContents = Selector.Register("allowGPUOptimizedContents");

    public static readonly Selector ArrayLength = Selector.Register("arrayLength");

    public static readonly Selector Buffer = Selector.Register("buffer");

    public static readonly Selector BufferBytesPerRow = Selector.Register("bufferBytesPerRow");

    public static readonly Selector BufferOffset = Selector.Register("bufferOffset");

    public static readonly Selector CompressionType = Selector.Register("compressionType");

    public static readonly Selector Depth = Selector.Register("depth");

    public static readonly Selector FirstMipmapInTail = Selector.Register("firstMipmapInTail");

    public static readonly Selector FramebufferOnly = Selector.Register("isFramebufferOnly");

    public static readonly Selector GetBytes = Selector.Register("getBytes:bytesPerRow:bytesPerImage:fromRegion:mipmapLevel:slice:");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Height = Selector.Register("height");

    public static readonly Selector Iosurface = Selector.Register("iosurface");

    public static readonly Selector IosurfacePlane = Selector.Register("iosurfacePlane");

    public static readonly Selector IsFramebufferOnly = Selector.Register("isFramebufferOnly");

    public static readonly Selector IsShareable = Selector.Register("isShareable");

    public static readonly Selector IsSparse = Selector.Register("isSparse");

    public static readonly Selector MipmapLevelCount = Selector.Register("mipmapLevelCount");

    public static readonly Selector NewRemoteTextureViewForDevice = Selector.Register("newRemoteTextureViewForDevice:");

    public static readonly Selector NewSharedTextureHandle = Selector.Register("newSharedTextureHandle");

    public static readonly Selector NewTextureView = Selector.Register("newTextureViewWithPixelFormat:");

    public static readonly Selector ParentRelativeLevel = Selector.Register("parentRelativeLevel");

    public static readonly Selector ParentRelativeSlice = Selector.Register("parentRelativeSlice");

    public static readonly Selector ParentTexture = Selector.Register("parentTexture");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector RemoteStorageTexture = Selector.Register("remoteStorageTexture");

    public static readonly Selector ReplaceRegion = Selector.Register("replaceRegion:mipmapLevel:slice:withBytes:bytesPerRow:bytesPerImage:");

    public static readonly Selector RootResource = Selector.Register("rootResource");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector Shareable = Selector.Register("isShareable");

    public static readonly Selector SparseTextureTier = Selector.Register("sparseTextureTier");

    public static readonly Selector Swizzle = Selector.Register("swizzle");

    public static readonly Selector TailSizeInBytes = Selector.Register("tailSizeInBytes");

    public static readonly Selector TextureType = Selector.Register("textureType");

    public static readonly Selector Usage = Selector.Register("usage");

    public static readonly Selector Width = Selector.Register("width");
}
