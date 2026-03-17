namespace Metal.NET;

public class MTLBuffer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLBuffer>
{
    #region INativeObject
    public static new MTLBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nuint Length
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferBindings.Length);
    }

    public MTLBuffer RemoteStorageBuffer
    {
        get => GetProperty(ref field, MTLBufferBindings.RemoteStorageBuffer);
    }

    public nuint GpuAddress
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferBindings.GpuAddress);
    }

    public MTLBufferSparseTier SparseBufferTier
    {
        get => (MTLBufferSparseTier)ObjectiveC.MsgSendLong(NativePtr, MTLBufferBindings.SparseBufferTier);
    }

    public nint Contents
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.Contents);
    }

    public void DidModifyRange(NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.DidModifyRange, range);
    }

    public MTLTexture NewTextureWithDescriptorOffsetBytesPerRow(MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.NewTextureWithDescriptor, descriptor.NativePtr, offset, bytesPerRow);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTensor NewTensorWithDescriptorOffsetError(MTLTensorDescriptor descriptor, nuint offset, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.NewTensorWithDescriptor, descriptor.NativePtr, offset, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void AddDebugMarkerRange(NSString marker, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.AddDebugMarker, marker.NativePtr, range);
    }

    public void RemoveAllDebugMarkers()
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.RemoveAllDebugMarkers);
    }

    public MTLBuffer NewRemoteBufferViewForDevice(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.NewRemoteBufferViewForDevice, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLBufferBindings
{
    public static readonly Selector AddDebugMarker = "addDebugMarker:range:";

    public static readonly Selector Contents = "contents";

    public static readonly Selector DidModifyRange = "didModifyRange:";

    public static readonly Selector GpuAddress = "gpuAddress";

    public static readonly Selector Length = "length";

    public static readonly Selector NewRemoteBufferViewForDevice = "newRemoteBufferViewForDevice:";

    public static readonly Selector NewTensorWithDescriptor = "newTensorWithDescriptor:offset:error:";

    public static readonly Selector NewTextureWithDescriptor = "newTextureWithDescriptor:offset:bytesPerRow:";

    public static readonly Selector RemoteStorageBuffer = "remoteStorageBuffer";

    public static readonly Selector RemoveAllDebugMarkers = "removeAllDebugMarkers";

    public static readonly Selector SparseBufferTier = "sparseBufferTier";
}
