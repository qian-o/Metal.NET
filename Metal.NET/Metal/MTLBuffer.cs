namespace Metal.NET;

public class MTLBuffer : IDisposable
{
    public MTLBuffer(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public MTLBuffer NewRemoteBufferViewForDevice(MTLDevice device)
    {
        MTLBuffer result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewRemoteBufferViewForDevice, device.NativePtr));

        return result;
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, uint offset, out NSError? error)
    {
        MTLTensor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewTensorOffsetError, descriptor.NativePtr, (nint)offset, out nint errorPtr));

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, uint offset, uint bytesPerRow)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferSelector.NewTextureOffsetBytesPerRow, descriptor.NativePtr, (nint)offset, (nint)bytesPerRow));

        return result;
    }

    public void RemoveAllDebugMarkers()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferSelector.RemoveAllDebugMarkers);
    }

}

file class MTLBufferSelector
{
    public static readonly Selector NewRemoteBufferViewForDevice = Selector.Register("newRemoteBufferViewForDevice:");

    public static readonly Selector NewTensorOffsetError = Selector.Register("newTensor:offset:error:");

    public static readonly Selector NewTextureOffsetBytesPerRow = Selector.Register("newTexture:offset:bytesPerRow:");

    public static readonly Selector RemoveAllDebugMarkers = Selector.Register("removeAllDebugMarkers");
}
