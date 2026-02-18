namespace Metal.NET;

public class MTLBuffer : IDisposable
{
    public MTLBuffer(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nint Contents
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.Contents);
    }

    public nuint GpuAddress
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferSelector.GpuAddress);
    }

    public nuint Length
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferSelector.Length);
    }

    public MTLBuffer RemoteStorageBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.RemoteStorageBuffer));
    }

    public MTLBufferSparseTier SparseBufferTier
    {
        get => (MTLBufferSparseTier)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLBufferSelector.SparseBufferTier));
    }

    public void AddDebugMarker(NSString marker, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferSelector.AddDebugMarkerRange, marker.NativePtr, range);
    }

    public void DidModifyRange(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferSelector.DidModifyRange, range);
    }

    public MTLBuffer NewRemoteBufferViewForDevice(MTLDevice device)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewRemoteBufferViewForDevice, device.NativePtr));

        return result;
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, nuint offset, out NSError? error)
    {
        MTLTensor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewTensorWithDescriptorOffsetError, descriptor.NativePtr, offset, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewTextureWithDescriptorOffsetBytesPerRow, descriptor.NativePtr, offset, bytesPerRow));

        return result;
    }

    public void RemoveAllDebugMarkers()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferSelector.RemoveAllDebugMarkers);
    }

    public static implicit operator nint(MTLBuffer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBuffer(nint value)
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

file class MTLBufferSelector
{
    public static readonly Selector Contents = Selector.Register("contents");

    public static readonly Selector GpuAddress = Selector.Register("gpuAddress");

    public static readonly Selector Length = Selector.Register("length");

    public static readonly Selector RemoteStorageBuffer = Selector.Register("remoteStorageBuffer");

    public static readonly Selector SparseBufferTier = Selector.Register("sparseBufferTier");

    public static readonly Selector AddDebugMarkerRange = Selector.Register("addDebugMarker:range:");

    public static readonly Selector DidModifyRange = Selector.Register("didModifyRange:");

    public static readonly Selector NewRemoteBufferViewForDevice = Selector.Register("newRemoteBufferViewForDevice:");

    public static readonly Selector NewTensorWithDescriptorOffsetError = Selector.Register("newTensorWithDescriptor:offset:error:");

    public static readonly Selector NewTextureWithDescriptorOffsetBytesPerRow = Selector.Register("newTextureWithDescriptor:offset:bytesPerRow:");

    public static readonly Selector RemoveAllDebugMarkers = Selector.Register("removeAllDebugMarkers");
}
