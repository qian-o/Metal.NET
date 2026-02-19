namespace Metal.NET;

public class MTLTexture(nint nativePtr) : NativeObject(nativePtr)
{
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
        get => GetProperty<MTLBuffer>(ref field, MTLTextureBindings.Buffer);
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
        get => GetProperty<MTLSharedTextureHandle>(ref field, MTLTextureBindings.NewSharedTextureHandle);
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
        get => GetProperty<MTLTexture>(ref field, MTLTextureBindings.ParentTexture);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.PixelFormat);
    }

    public MTLTexture? RemoteStorageTexture
    {
        get => GetProperty<MTLTexture>(ref field, MTLTextureBindings.RemoteStorageTexture);
    }

    public MTLResource? RootResource
    {
        get => GetProperty<MTLResource>(ref field, MTLTextureBindings.RootResource);
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
        return ptr is not 0 ? new MTLTexture(ptr) : null;
    }

    public MTLTexture? NewTextureView(MTLPixelFormat pixelFormat)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureView, (nuint)pixelFormat);
        return ptr is not 0 ? new MTLTexture(ptr) : null;
    }

    public MTLTexture? NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureView, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange);
        return ptr is not 0 ? new MTLTexture(ptr) : null;
    }

    public MTLTexture? NewTextureView(MTLTextureViewDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureView, descriptor.NativePtr);
        return ptr is not 0 ? new MTLTexture(ptr) : null;
    }

    public MTLTexture? NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange, MTLTextureSwizzleChannels swizzle)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureView, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange, swizzle);
        return ptr is not 0 ? new MTLTexture(ptr) : null;
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
    public static readonly Selector AllowGPUOptimizedContents = "allowGPUOptimizedContents";

    public static readonly Selector ArrayLength = "arrayLength";

    public static readonly Selector Buffer = "buffer";

    public static readonly Selector BufferBytesPerRow = "bufferBytesPerRow";

    public static readonly Selector BufferOffset = "bufferOffset";

    public static readonly Selector CompressionType = "compressionType";

    public static readonly Selector Depth = "depth";

    public static readonly Selector FirstMipmapInTail = "firstMipmapInTail";

    public static readonly Selector FramebufferOnly = "isFramebufferOnly";

    public static readonly Selector GetBytes = "getBytes:bytesPerRow:bytesPerImage:fromRegion:mipmapLevel:slice:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Height = "height";

    public static readonly Selector Iosurface = "iosurface";

    public static readonly Selector IosurfacePlane = "iosurfacePlane";

    public static readonly Selector IsFramebufferOnly = "isFramebufferOnly";

    public static readonly Selector IsShareable = "isShareable";

    public static readonly Selector IsSparse = "isSparse";

    public static readonly Selector MipmapLevelCount = "mipmapLevelCount";

    public static readonly Selector NewRemoteTextureViewForDevice = "newRemoteTextureViewForDevice:";

    public static readonly Selector NewSharedTextureHandle = "newSharedTextureHandle";

    public static readonly Selector NewTextureView = "newTextureViewWithPixelFormat:";

    public static readonly Selector ParentRelativeLevel = "parentRelativeLevel";

    public static readonly Selector ParentRelativeSlice = "parentRelativeSlice";

    public static readonly Selector ParentTexture = "parentTexture";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector RemoteStorageTexture = "remoteStorageTexture";

    public static readonly Selector ReplaceRegion = "replaceRegion:mipmapLevel:slice:withBytes:bytesPerRow:bytesPerImage:";

    public static readonly Selector RootResource = "rootResource";

    public static readonly Selector SampleCount = "sampleCount";

    public static readonly Selector Shareable = "isShareable";

    public static readonly Selector SparseTextureTier = "sparseTextureTier";

    public static readonly Selector Swizzle = "swizzle";

    public static readonly Selector TailSizeInBytes = "tailSizeInBytes";

    public static readonly Selector TextureType = "textureType";

    public static readonly Selector Usage = "usage";

    public static readonly Selector Width = "width";
}
