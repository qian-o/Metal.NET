namespace Metal.NET;

/// <summary>A resource that holds formatted image data.</summary>
public class MTLTexture(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLTexture>
{
    #region INativeObject
    public static new MTLTexture Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTexture New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Querying texture attributes - Properties

    /// <summary>The dimension and arrangement of the texture image data.</summary>
    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindings.TextureType);
    }

    /// <summary>The format of pixels in the texture.</summary>
    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindings.PixelFormat);
    }

    /// <summary>The width of the texture image for the base level mipmap, in pixels.</summary>
    public nuint Width
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.Width);
    }

    /// <summary>The height of the texture image for the base level mipmap, in pixels.</summary>
    public nuint Height
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.Height);
    }

    /// <summary>The depth of the texture image for the base level mipmap, in pixels.</summary>
    public nuint Depth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.Depth);
    }

    /// <summary>The number of mipmap levels in the texture.</summary>
    public nuint MipmapLevelCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.MipmapLevelCount);
    }

    /// <summary>The number of slices in the texture array.</summary>
    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.ArrayLength);
    }

    /// <summary>The number of samples in each pixel.</summary>
    public nuint SampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.SampleCount);
    }

    /// <summary>A Boolean value that indicates whether the texture can only be used as a render target.</summary>
    public Bool8 IsFramebufferOnly
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindings.IsFramebufferOnly);
    }

    /// <summary>Options that determine how you can use the texture.</summary>
    public MTLTextureUsage Usage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindings.Usage);
    }

    /// <summary>A Boolean value indicating whether the GPU is allowed to adjust the contents of the texture to improve GPU performance.</summary>
    public Bool8 AllowGPUOptimizedContents
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindings.AllowGPUOptimizedContents);
    }

    /// <summary>A Boolean indicating whether this texture can be shared with other processes.</summary>
    public Bool8 IsShareable
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindings.IsShareable);
    }

    /// <summary>The pattern that the GPU applies to pixels when you read or sample pixels from the texture.</summary>
    public MTLTextureSwizzleChannels Swizzle
    {
        get => ObjectiveC.MsgSendMTLTextureSwizzleChannels(NativePtr, MTLTextureBindings.Swizzle);
    }
    #endregion

    #region Getting information about the IOSurface the texture was created from - Properties

    /// <summary>A reference to the underlying surface instance for the texture, if applicable.</summary>
    public nint Iosurface
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.Iosurface);
    }

    /// <summary>The number of a plane within the underlying surface instance for the texture, if applicable.</summary>
    public nuint IosurfacePlane
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.IosurfacePlane);
    }
    #endregion

    #region Getting information about ancestor resources - Properties

    /// <summary>The base level of the parent texture used to create this texture.</summary>
    public nuint ParentRelativeLevel
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.ParentRelativeLevel);
    }

    /// <summary>The base slice of the parent texture used to create this texture.</summary>
    public nuint ParentRelativeSlice
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.ParentRelativeSlice);
    }

    /// <summary>The source buffer used to create this texture, if any.</summary>
    public MTLBuffer Buffer
    {
        get => GetProperty(ref field, MTLTextureBindings.Buffer);
    }

    /// <summary>The offset in the source buffer where the texture’s data comes from.</summary>
    public nuint BufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.BufferOffset);
    }

    /// <summary>The number of bytes in each row of the texture’s source buffer.</summary>
    public nuint BufferBytesPerRow
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.BufferBytesPerRow);
    }

    /// <summary>The resource that owns the storage for this texture.</summary>
    [Obsolete("Use parent or buffer instead.")]
    public MTLResource RootResource
    {
        get => GetProperty(ref field, MTLTextureBindings.RootResource);
    }
    #endregion

    #region Creating views of textures on other GPUs - Properties

    /// <summary>The texture on another GPU that the texture was created from, if any.</summary>
    public MTLTexture RemoteStorageTexture
    {
        get => GetProperty(ref field, MTLTextureBindings.RemoteStorageTexture);
    }
    #endregion

    #region Querying sparse properties - Properties

    /// <summary>A Boolean value that indicates whether this is a sparse texture.</summary>
    public Bool8 IsSparse
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindings.IsSparse);
    }

    /// <summary>The index of the first mipmap in the tail.</summary>
    public nuint FirstMipmapInTail
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.FirstMipmapInTail);
    }

    /// <summary>The size of the sparse texture tail, in bytes.</summary>
    public nuint TailSizeInBytes
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindings.TailSizeInBytes);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLTextureCompressionType CompressionType
    {
        get => (MTLTextureCompressionType)ObjectiveC.MsgSendLong(NativePtr, MTLTextureBindings.CompressionType);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureBindings.GpuResourceID);
    }

    public MTLTextureSparseTier SparseTextureTier
    {
        get => (MTLTextureSparseTier)ObjectiveC.MsgSendLong(NativePtr, MTLTextureBindings.SparseTextureTier);
    }
    #endregion

    /// <summary>Deprecated: please use isFramebufferOnly instead</summary>
    [Obsolete("please use isFramebufferOnly instead")]
    public Bool8 FramebufferOnly
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindings.FramebufferOnly);
    }

    public MTLTexture ParentTexture
    {
        get => GetProperty(ref field, MTLTextureBindings.ParentTexture);
    }

    /// <summary>Deprecated: please use isShareable instead</summary>
    [Obsolete("please use isShareable instead")]
    public Bool8 Shareable
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindings.Shareable);
    }

    #region Copying data into a texture image - Methods

    /// <summary>Copies pixel data into a section of a texture slice.</summary>
    public void ReplaceRegion(MTLRegion region, nuint level, nuint slice, nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureBindings.ReplaceRegion, region, level, slice, pixelBytes, bytesPerRow, bytesPerImage);
    }

    /// <summary>Copies pixel data into a section of a texture slice.</summary>
    public void ReplaceRegion(MTLRegion region, nuint level, nint pixelBytes, nuint bytesPerRow)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureBindings.ReplaceRegionmipmapLevelwithBytesbytesPerRow, region, level, pixelBytes, bytesPerRow);
    }
    #endregion

    #region Copying data from a texture image - Methods

    /// <summary>Copies pixel data from the texture to a buffer in system memory.</summary>
    public void GetBytes(nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage, MTLRegion region, nuint level, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureBindings.GetBytes, pixelBytes, bytesPerRow, bytesPerImage, region, level, slice);
    }

    /// <summary>Copies pixel data from the texture to a buffer in system memory.</summary>
    public void GetBytes(nint pixelBytes, nuint bytesPerRow, MTLRegion region, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureBindings.GetBytesbytesPerRowfromRegionmipmapLevel, pixelBytes, bytesPerRow, region, level);
    }
    #endregion

    #region Creating textures by reinterpreting existing texture data - Methods

    /// <summary>Creates a new view of the texture, reinterpreting its data using a different pixel format.</summary>
    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewTextureView, (nuint)pixelFormat);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a new view of the texture, reinterpreting its data using a different pixel format.</summary>
    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewTextureViewWithPixelFormattextureTypelevelsslices, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a new view of the texture, reinterpreting its data using a different pixel format.</summary>
    public MTLTexture NewTextureView(MTLTextureViewDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewTextureViewWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a new view of the texture, reinterpreting its data using a different pixel format.</summary>
    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange, MTLTextureSwizzleChannels swizzle)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewTextureViewWithPixelFormattextureTypelevelsslicesswizzle, (nuint)pixelFormat, (nuint)textureType, levelRange, sliceRange, swizzle);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating a shared texture handle - Methods

    /// <summary>Creates a new texture handle from a shareable texture.</summary>
    public MTLSharedTextureHandle NewSharedTextureHandle()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewSharedTextureHandle);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Creating views of textures on other GPUs - Methods

    /// <summary>Creates a remote texture view for another GPU in the same peer group.</summary>
    public MTLTexture NewRemoteTextureViewForDevice(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindings.NewRemoteTextureViewForDevice, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
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
