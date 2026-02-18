namespace Metal.NET;

public partial class MTLBuffer : NativeObject
{
    public MTLBuffer(nint nativePtr) : base(nativePtr)
    {
    }

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

    public MTLBuffer? RemoteStorageBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.RemoteStorageBuffer);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLBufferSparseTier SparseBufferTier
    {
        get => (MTLBufferSparseTier)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.SparseBufferTier);
    }

    public void AddDebugMarker(NSString marker, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferSelector.AddDebugMarker, marker.NativePtr, range);
    }

    public void DidModifyRange(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferSelector.DidModifyRange, range);
    }

    public MTLBuffer? NewRemoteBufferViewForDevice(MTLDevice device)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewRemoteBufferViewForDevice, device.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLTensor? NewTensor(MTLTensorDescriptor descriptor, nuint offset, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewTensor, descriptor.NativePtr, offset, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewTexture, descriptor.NativePtr, offset, bytesPerRow);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void RemoveAllDebugMarkers()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferSelector.RemoveAllDebugMarkers);
    }
}

file static class MTLBufferSelector
{
    public static readonly Selector AddDebugMarker = Selector.Register("addDebugMarker::");

    public static readonly Selector Contents = Selector.Register("contents");

    public static readonly Selector DidModifyRange = Selector.Register("didModifyRange:");

    public static readonly Selector GpuAddress = Selector.Register("gpuAddress");

    public static readonly Selector Length = Selector.Register("length");

    public static readonly Selector NewRemoteBufferViewForDevice = Selector.Register("newRemoteBufferViewForDevice:");

    public static readonly Selector NewTensor = Selector.Register("newTensor::::");

    public static readonly Selector NewTexture = Selector.Register("newTexture:::");

    public static readonly Selector RemoteStorageBuffer = Selector.Register("remoteStorageBuffer");

    public static readonly Selector RemoveAllDebugMarkers = Selector.Register("removeAllDebugMarkers");

    public static readonly Selector SparseBufferTier = Selector.Register("sparseBufferTier");
}
