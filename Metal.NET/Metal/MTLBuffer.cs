namespace Metal.NET;

public class MTLBuffer(nint nativePtr, bool retain) : MTLResource(nativePtr, retain)
{
    public nint Contents
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferBindings.Contents);
    }

    public nuint GpuAddress
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferBindings.GpuAddress);
    }

    public nuint Length
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBufferBindings.Length);
    }

    public MTLBuffer? RemoteStorageBuffer
    {
        get => GetProperty(ref field, MTLBufferBindings.RemoteStorageBuffer);
    }

    public MTLBufferSparseTier SparseBufferTier
    {
        get => (MTLBufferSparseTier)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferBindings.SparseBufferTier);
    }

    public void AddDebugMarker(NSString marker, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferBindings.AddDebugMarker, marker.NativePtr, range);
    }

    public void DidModifyRange(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferBindings.DidModifyRange, range);
    }

    public MTLBuffer? NewRemoteBufferViewForDevice(MTLDevice device)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferBindings.NewRemoteBufferViewForDevice, device.NativePtr);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTLTensor? NewTensor(MTLTensorDescriptor descriptor, nuint offset, out NSError? error)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferBindings.NewTensor, descriptor.NativePtr, offset, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr, true) : null;

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTLTexture? NewTexture(MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferBindings.NewTexture, descriptor.NativePtr, offset, bytesPerRow);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public void RemoveAllDebugMarkers()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferBindings.RemoveAllDebugMarkers);
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

    public static readonly Selector NewTensor = "newTensorWithDescriptor:offset:error:";

    public static readonly Selector NewTexture = "newTextureWithDescriptor:offset:bytesPerRow:";

    public static readonly Selector RemoteStorageBuffer = "remoteStorageBuffer";

    public static readonly Selector RemoveAllDebugMarkers = "removeAllDebugMarkers";

    public static readonly Selector SparseBufferTier = "sparseBufferTier";
}
