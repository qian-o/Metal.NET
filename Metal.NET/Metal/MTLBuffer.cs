namespace Metal.NET;

public class MTLBuffer(nint nativePtr) : MTLResource(nativePtr)
{

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
        get => GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.RemoteStorageBuffer));
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
        return GetNullableObject<MTLBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewRemoteBufferViewForDevice, device.NativePtr));
    }

    public MTLTensor? NewTensor(MTLTensorDescriptor descriptor, nuint offset, out NSError? error)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewTensor, descriptor.NativePtr, offset, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return GetNullableObject<MTLTensor>(ptr);
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow)
    {
        return GetNullableObject<MTLTexture>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewTexture, descriptor.NativePtr, offset, bytesPerRow));
    }

    public void RemoveAllDebugMarkers()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferSelector.RemoveAllDebugMarkers);
    }
}

file static class MTLBufferSelector
{
    public static readonly Selector AddDebugMarker = Selector.Register("addDebugMarker:range:");

    public static readonly Selector Contents = Selector.Register("contents");

    public static readonly Selector DidModifyRange = Selector.Register("didModifyRange:");

    public static readonly Selector GpuAddress = Selector.Register("gpuAddress");

    public static readonly Selector Length = Selector.Register("length");

    public static readonly Selector NewRemoteBufferViewForDevice = Selector.Register("newRemoteBufferViewForDevice:");

    public static readonly Selector NewTensor = Selector.Register("newTensorWithDescriptor:offset:error:");

    public static readonly Selector NewTexture = Selector.Register("newTextureWithDescriptor:offset:bytesPerRow:");

    public static readonly Selector RemoteStorageBuffer = Selector.Register("remoteStorageBuffer");

    public static readonly Selector RemoveAllDebugMarkers = Selector.Register("removeAllDebugMarkers");

    public static readonly Selector SparseBufferTier = Selector.Register("sparseBufferTier");
}
