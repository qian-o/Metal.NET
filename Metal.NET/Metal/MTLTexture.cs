namespace Metal.NET;

public partial class MTLTexture : NativeObject
{
    public MTLTexture(nint nativePtr) : base(nativePtr)
    {
    }

    public bool AllowGPUOptimizedContents
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.AllowGPUOptimizedContents);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.ArrayLength);
    }

    public MTLBuffer? Buffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.Buffer);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint BufferBytesPerRow
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.BufferBytesPerRow);
    }

    public nuint BufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.BufferOffset);
    }

    public MTLTextureCompressionType CompressionType
    {
        get => (MTLTextureCompressionType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.CompressionType);
    }

    public nuint Depth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.Depth);
    }

    public nuint FirstMipmapInTail
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.FirstMipmapInTail);
    }

    public bool FramebufferOnly
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.FramebufferOnly);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureSelector.GpuResourceID);
    }

    public nuint Height
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.Height);
    }

    public nint Iosurface
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.Iosurface);
    }

    public nuint IosurfacePlane
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.IosurfacePlane);
    }

    public bool IsFramebufferOnly
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.IsFramebufferOnly);
    }

    public bool IsShareable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.IsShareable);
    }

    public bool IsSparse
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.IsSparse);
    }

    public nuint MipmapLevelCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.MipmapLevelCount);
    }

    public MTLSharedTextureHandle? NewSharedTextureHandle
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewSharedTextureHandle);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint ParentRelativeLevel
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.ParentRelativeLevel);
    }

    public nuint ParentRelativeSlice
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.ParentRelativeSlice);
    }

    public MTLTexture? ParentTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.ParentTexture);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.PixelFormat);
    }

    public MTLTexture? RemoteStorageTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.RemoteStorageTexture);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLResource? RootResource
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.RootResource);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.SampleCount);
    }

    public bool Shareable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureSelector.Shareable);
    }

    public MTLTextureSparseTier SparseTextureTier
    {
        get => (MTLTextureSparseTier)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.SparseTextureTier);
    }

    public MTLTextureSwizzleChannels Swizzle
    {
        get => ObjectiveCRuntime.MsgSendMTLTextureSwizzleChannels(NativePtr, MTLTextureSelector.Swizzle);
    }

    public nuint TailSizeInBytes
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.TailSizeInBytes);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.TextureType);
    }

    public nuint Usage
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.Usage);
    }

    public nuint Width
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureSelector.Width);
    }

    public void GetBytes(nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage, MTLRegion region, nuint level, nuint slice)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureSelector.GetBytes, pixelBytes, bytesPerRow, bytesPerImage, region, level, slice);
    }

    public void GetBytes(nint pixelBytes, nuint bytesPerRow, MTLRegion region, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureSelector.GetBytes, pixelBytes, bytesPerRow, region, level);
    }

    public MTLTexture? NewRemoteTextureViewForDevice(MTLDevice device)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewRemoteTextureViewForDevice, device.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLTexture? NewTextureView(MTLPixelFormat pixelFormat)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewTextureView, (nuint)pixelFormat);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLTexture? NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewTextureView, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLTexture? NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange, MTLTextureSwizzleChannels swizzle)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewTextureView, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange, swizzle);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void ReplaceRegion(MTLRegion region, nuint level, nuint slice, nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureSelector.ReplaceRegion, region, level, slice, pixelBytes, bytesPerRow, bytesPerImage);
    }

    public void ReplaceRegion(MTLRegion region, nuint level, nint pixelBytes, nuint bytesPerRow)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureSelector.ReplaceRegion, region, level, pixelBytes, bytesPerRow);
    }
}

file static class MTLTextureSelector
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

    public static readonly Selector GetBytes = Selector.Register("getBytes::::::");

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

    public static readonly Selector NewTextureView = Selector.Register("newTextureView:");

    public static readonly Selector ParentRelativeLevel = Selector.Register("parentRelativeLevel");

    public static readonly Selector ParentRelativeSlice = Selector.Register("parentRelativeSlice");

    public static readonly Selector ParentTexture = Selector.Register("parentTexture");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector RemoteStorageTexture = Selector.Register("remoteStorageTexture");

    public static readonly Selector ReplaceRegion = Selector.Register("replaceRegion::::::");

    public static readonly Selector RootResource = Selector.Register("rootResource");

    public static readonly Selector SampleCount = Selector.Register("sampleCount");

    public static readonly Selector Shareable = Selector.Register("shareable");

    public static readonly Selector SparseTextureTier = Selector.Register("sparseTextureTier");

    public static readonly Selector Swizzle = Selector.Register("swizzle");

    public static readonly Selector TailSizeInBytes = Selector.Register("tailSizeInBytes");

    public static readonly Selector TextureType = Selector.Register("textureType");

    public static readonly Selector Usage = Selector.Register("usage");

    public static readonly Selector Width = Selector.Register("width");
}
