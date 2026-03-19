namespace Metal.NET;

public partial class MTLTexture(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLTexture>
{
    #region INativeObject
    public static new MTLTexture Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTexture New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    /// <summary>
    /// Deprecated: Use parentTexture or buffer instead
    /// </summary>
    [Obsolete("Use parentTexture or buffer instead")]
    public MTLResource RootResource
    {
        get => GetProperty(ref field, MTLTextureBindings.RootResource);
    }

    public MTLTexture ParentTexture
    {
        get => GetProperty(ref field, MTLTextureBindings.ParentTexture);
    }

    public nuint ParentRelativeLevel
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.ParentRelativeLevel);
    }

    public nuint ParentRelativeSlice
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.ParentRelativeSlice);
    }

    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLTextureBindings.Buffer);
    }

    public nuint BufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.BufferOffset);
    }

    public nuint BufferBytesPerRow
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.BufferBytesPerRow);
    }

    public nint Iosurface
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.Iosurface);
    }

    public nuint IosurfacePlane
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.IosurfacePlane);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindings.TextureType);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindings.PixelFormat);
    }

    public nuint Width
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.Width);
    }

    public nuint Height
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.Height);
    }

    public nuint Depth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.Depth);
    }

    public nuint MipmapLevelCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.MipmapLevelCount);
    }

    public nuint SampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.SampleCount);
    }

    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.ArrayLength);
    }

    public MTLTextureUsage Usage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindings.Usage);
    }

    public Bool8 IsShareable
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindings.IsShareable);
    }

    public Bool8 IsFramebufferOnly
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindings.IsFramebufferOnly);
    }

    public nuint FirstMipmapInTail
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.FirstMipmapInTail);
    }

    public nuint TailSizeInBytes
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.TailSizeInBytes);
    }

    public Bool8 IsSparse
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindings.IsSparse);
    }

    public Bool8 AllowGPUOptimizedContents
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindings.AllowGPUOptimizedContents);
    }

    public MTLTextureCompressionType CompressionType
    {
        get => (MTLTextureCompressionType)ObjectiveC.MsgSendLong(NativePtr, MTLTextureBindings.CompressionType);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureBindings.GpuResourceID);
    }

    public MTLTexture RemoteStorageTexture
    {
        get => GetProperty(ref field, MTLTextureBindings.RemoteStorageTexture);
    }

    public MTLTextureSwizzleChannels Swizzle
    {
        get => ObjectiveC.MsgSendMTLTextureSwizzleChannels(NativePtr, MTLTextureBindings.Swizzle);
    }

    public MTLTextureSparseTier SparseTextureTier
    {
        get => (MTLTextureSparseTier)ObjectiveC.MsgSendLong(NativePtr, MTLTextureBindings.SparseTextureTier);
    }

    public void GetBytes(nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage, MTLRegion region, nuint level, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureBindings.GetBytesBytesPerRowBytesPerImageFromRegionMipmapLevelSlice, pixelBytes, bytesPerRow, bytesPerImage, region, level, slice);
    }

    public void Replace(MTLRegion region, nuint level, nuint slice, nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureBindings.ReplaceRegionMipmapLevelSliceWithBytesBytesPerRowBytesPerImage, region, level, slice, pixelBytes, bytesPerRow, bytesPerImage);
    }

    public void GetBytes(nint pixelBytes, nuint bytesPerRow, MTLRegion region, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureBindings.GetBytesBytesPerRowFromRegionMipmapLevel, pixelBytes, bytesPerRow, region, level);
    }

    public void Replace(MTLRegion region, nuint level, nint pixelBytes, nuint bytesPerRow)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureBindings.ReplaceRegionMipmapLevelWithBytesBytesPerRow, region, level, pixelBytes, bytesPerRow);
    }

    public MTLTexture MakeTextureView(MTLPixelFormat pixelFormat)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewTextureViewWithPixelFormat, (nuint)pixelFormat);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture MakeTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewTextureViewWithPixelFormatTextureTypeLevelsSlices, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLSharedTextureHandle MakeSharedTextureHandle()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewSharedTextureHandle);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture MakeTextureView(MTLTextureViewDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewTextureViewWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture MakeRemoteTextureView(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewRemoteTextureViewForDevice, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTexture MakeTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange, MTLTextureSwizzleChannels swizzle)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewTextureViewWithPixelFormatTextureTypeLevelsSlicesSwizzle, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange, swizzle);

        return new(nativePtr, NativeObjectOwnership.Owned);
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

    public static readonly Selector GetBytesBytesPerRowBytesPerImageFromRegionMipmapLevelSlice = "getBytes:bytesPerRow:bytesPerImage:fromRegion:mipmapLevel:slice:";

    public static readonly Selector GetBytesBytesPerRowFromRegionMipmapLevel = "getBytes:bytesPerRow:fromRegion:mipmapLevel:";

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

    public static readonly Selector NewTextureViewWithDescriptor = "newTextureViewWithDescriptor:";

    public static readonly Selector NewTextureViewWithPixelFormat = "newTextureViewWithPixelFormat:";

    public static readonly Selector NewTextureViewWithPixelFormatTextureTypeLevelsSlices = "newTextureViewWithPixelFormat:textureType:levels:slices:";

    public static readonly Selector NewTextureViewWithPixelFormatTextureTypeLevelsSlicesSwizzle = "newTextureViewWithPixelFormat:textureType:levels:slices:swizzle:";

    public static readonly Selector ParentRelativeLevel = "parentRelativeLevel";

    public static readonly Selector ParentRelativeSlice = "parentRelativeSlice";

    public static readonly Selector ParentTexture = "parentTexture";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector RemoteStorageTexture = "remoteStorageTexture";

    public static readonly Selector ReplaceRegionMipmapLevelSliceWithBytesBytesPerRowBytesPerImage = "replaceRegion:mipmapLevel:slice:withBytes:bytesPerRow:bytesPerImage:";

    public static readonly Selector ReplaceRegionMipmapLevelWithBytesBytesPerRow = "replaceRegion:mipmapLevel:withBytes:bytesPerRow:";

    public static readonly Selector RootResource = "rootResource";

    public static readonly Selector SampleCount = "sampleCount";

    public static readonly Selector SparseTextureTier = "sparseTextureTier";

    public static readonly Selector Swizzle = "swizzle";

    public static readonly Selector TailSizeInBytes = "tailSizeInBytes";

    public static readonly Selector TextureType = "textureType";

    public static readonly Selector Usage = "usage";

    public static readonly Selector Width = "width";
}
