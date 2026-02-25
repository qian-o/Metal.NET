namespace Metal.NET;

public class MTLTexture(nint nativePtr, bool ownsReference) : MTLResource(nativePtr, ownsReference), INativeObject<MTLTexture>
{
    public static new MTLTexture Null => Create(0, false);
    public static new MTLTexture Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public Bool8 AllowGPUOptimizedContents
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindings.AllowGPUOptimizedContents);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.ArrayLength);
    }

    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLTextureBindings.Buffer);
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

    public Bool8 FramebufferOnly
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

    public Bool8 IsFramebufferOnly
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindings.IsFramebufferOnly);
    }

    public Bool8 IsShareable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindings.IsShareable);
    }

    public Bool8 IsSparse
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindings.IsSparse);
    }

    public nuint MipmapLevelCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.MipmapLevelCount);
    }

    public nuint ParentRelativeLevel
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.ParentRelativeLevel);
    }

    public nuint ParentRelativeSlice
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.ParentRelativeSlice);
    }

    public MTLTexture ParentTexture
    {
        get => GetProperty(ref field, MTLTextureBindings.ParentTexture);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.PixelFormat);
    }

    public MTLTexture RemoteStorageTexture
    {
        get => GetProperty(ref field, MTLTextureBindings.RemoteStorageTexture);
    }

    public MTLResource RootResource
    {
        get => GetProperty(ref field, MTLTextureBindings.RootResource);
    }

    public nuint SampleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindings.SampleCount);
    }

    public Bool8 Shareable
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureBindings.GetBytesbytesPerRowfromRegionmipmapLevel, pixelBytes, bytesPerRow, region, level);
    }

    public MTLTexture NewRemoteTextureViewForDevice(MTLDevice device)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewRemoteTextureViewForDevice, device.NativePtr);

        return new(nativePtr, true);
    }

    public MTLSharedTextureHandle NewSharedTextureHandle()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewSharedTextureHandle);

        return new(nativePtr, true);
    }

    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureView, (nuint)pixelFormat);

        return new(nativePtr, true);
    }

    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureViewWithPixelFormattextureTypelevelsslices, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange);

        return new(nativePtr, true);
    }

    public MTLTexture NewTextureView(MTLTextureViewDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureViewWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, true);
    }

    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange, MTLTextureSwizzleChannels swizzle)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureBindings.NewTextureViewWithPixelFormattextureTypelevelsslicesswizzle, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange, swizzle);

        return new(nativePtr, true);
    }

    public void ReplaceRegion(MTLRegion region, nuint level, nuint slice, nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureBindings.ReplaceRegion, region, level, slice, pixelBytes, bytesPerRow, bytesPerImage);
    }

    public void ReplaceRegion(MTLRegion region, nuint level, nint pixelBytes, nuint bytesPerRow)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureBindings.ReplaceRegionmipmapLevelwithBytesbytesPerRow, region, level, pixelBytes, bytesPerRow);
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

    public static readonly Selector GetBytesbytesPerRowfromRegionmipmapLevel = "getBytes:bytesPerRow:fromRegion:mipmapLevel:";

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

    public static readonly Selector NewTextureViewWithDescriptor = "newTextureViewWithDescriptor:";

    public static readonly Selector NewTextureViewWithPixelFormattextureTypelevelsslices = "newTextureViewWithPixelFormat:textureType:levels:slices:";

    public static readonly Selector NewTextureViewWithPixelFormattextureTypelevelsslicesswizzle = "newTextureViewWithPixelFormat:textureType:levels:slices:swizzle:";

    public static readonly Selector ParentRelativeLevel = "parentRelativeLevel";

    public static readonly Selector ParentRelativeSlice = "parentRelativeSlice";

    public static readonly Selector ParentTexture = "parentTexture";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector RemoteStorageTexture = "remoteStorageTexture";

    public static readonly Selector ReplaceRegion = "replaceRegion:mipmapLevel:slice:withBytes:bytesPerRow:bytesPerImage:";

    public static readonly Selector ReplaceRegionmipmapLevelwithBytesbytesPerRow = "replaceRegion:mipmapLevel:withBytes:bytesPerRow:";

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
