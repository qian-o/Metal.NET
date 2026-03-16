namespace Metal.NET;

/// <summary>A resource that stores data in a format defined by your app.</summary>
public class MTLBuffer(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLBuffer>
{
    #region INativeObject
    public static new MTLBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Reading buffer length - Properties

    /// <summary>The logical size of the buffer, in bytes.</summary>
    public nuint Length
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferBindings.Length);
    }
    #endregion

    #region Creating views of buffers on other GPUs - Properties

    /// <summary>The buffer on another GPU that the buffer was created from, if any.</summary>
    public MTLBuffer RemoteStorageBuffer
    {
        get => GetProperty(ref field, MTLBufferBindings.RemoteStorageBuffer);
    }
    #endregion

    #region Instance Properties - Properties

    public nuint GpuAddress
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferBindings.GpuAddress);
    }

    public MTLBufferSparseTier SparseBufferTier
    {
        get => (MTLBufferSparseTier)ObjectiveC.MsgSendLong(NativePtr, MTLBufferBindings.SparseBufferTier);
    }
    #endregion

    #region Creating a texture that shares buffer data - Methods

    /// <summary>Creates a texture that shares its storage with the buffer.</summary>
    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.NewTexture, descriptor.NativePtr, offset, bytesPerRow);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Reading the buffer’s data on the CPU - Methods

    /// <summary>Gets the system address of the buffer’s storage allocation.</summary>
    public nint Contents()
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.Contents);
    }
    #endregion

    #region Synchronizing data to the GPU for managed buffers - Methods

    /// <summary>Informs the GPU that the CPU has modified a section of the buffer.</summary>
    public void DidModifyRange(NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.DidModifyRange, range);
    }
    #endregion

    #region Debugging buffers - Methods

    /// <summary>Adds a debug marker string to a specific buffer range.</summary>
    public void AddDebugMarker(NSString marker, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.AddDebugMarker, marker.NativePtr, range);
    }

    /// <summary>Removes all debug marker strings from the buffer.</summary>
    public void RemoveAllDebugMarkers()
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.RemoveAllDebugMarkers);
    }
    #endregion

    #region Creating views of buffers on other GPUs - Methods

    /// <summary>Creates a remote view of the buffer for another GPU in the same peer group.</summary>
    public MTLBuffer NewRemoteBufferViewForDevice(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.NewRemoteBufferViewForDevice, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Creates a tensor that shares storage with this buffer.</summary>
    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, nuint offset, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.NewTensor, descriptor.NativePtr, offset, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
}

file static class MTLBufferBindings
{
    public static readonly Selector AddDebugMarker = "addDebugMarker:range:";

    public static readonly Selector Contents = "contents";

    public static readonly Selector DidModifyRange = "didModifyRange:";

    public static readonly Selector GpuAddress = "gpuAddress";

    public static readonly Selector Length = "length";

    public static readonly Selector NewRemoteBufferViewForDevice = "newRemoteBufferViewForDevice:";

    public static readonly Selector NewTensor = "newTensorWithDescriptor:offset:error:";

    public static readonly Selector NewTexture = "newTextureWithDescriptor:offset:bytesPerRow:";

    public static readonly Selector RemoteStorageBuffer = "remoteStorageBuffer";

    public static readonly Selector RemoveAllDebugMarkers = "removeAllDebugMarkers";

    public static readonly Selector SparseBufferTier = "sparseBufferTier";
}
