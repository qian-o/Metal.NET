namespace Metal.NET;

public class MTLBuffer(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLBuffer>
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

    public nint Contents()
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.Contents);
    }

    public void DidModifyRange(NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.DidModifyRange, range);
    }

    public MTLTexture MakeTexture(MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.MakeTexture, descriptor.NativePtr, offset, bytesPerRow);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTensor MakeTensor(MTLTensorDescriptor descriptor, nuint offset, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.MakeTensor, descriptor.NativePtr, offset, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void AddDebugMarker(NSString marker, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.AddDebugMarker, marker.NativePtr, range);
    }

    public void RemoveAllDebugMarkers()
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.RemoveAllDebugMarkers);
    }

    public MTLBuffer MakeRemoteBufferView(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.MakeRemoteBufferView, device.NativePtr);

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

    public static readonly Selector MakeRemoteBufferView = "newRemoteBufferViewForDevice:";

    public static readonly Selector MakeTensor = "newTensorWithDescriptor:offset:error:";

    public static readonly Selector MakeTexture = "newTextureWithDescriptor:offset:bytesPerRow:";

    public static readonly Selector RemoteStorageBuffer = "remoteStorageBuffer";

    public static readonly Selector RemoveAllDebugMarkers = "removeAllDebugMarkers";

    public static readonly Selector SparseBufferTier = "sparseBufferTier";
}
