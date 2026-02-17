#nullable enable

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
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBufferSelector.NewRemoteBufferViewForDevice, device.NativePtr));

        return result;
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, uint offset, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLTensor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBufferSelector.NewTensorOffsetError, descriptor.NativePtr, (nint)offset, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, uint offset, uint bytesPerRow)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBufferSelector.NewTextureOffsetBytesPerRow, descriptor.NativePtr, (nint)offset, (nint)bytesPerRow));

        return result;
    }

    public void RemoveAllDebugMarkers()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBufferSelector.RemoveAllDebugMarkers);
    }

}

file class MTLBufferSelector
{
    public static readonly Selector NewRemoteBufferViewForDevice = Selector.Register("newRemoteBufferViewForDevice:");
    public static readonly Selector NewTensorOffsetError = Selector.Register("newTensor:offset:error:");
    public static readonly Selector NewTextureOffsetBytesPerRow = Selector.Register("newTexture:offset:bytesPerRow:");
    public static readonly Selector RemoveAllDebugMarkers = Selector.Register("removeAllDebugMarkers");
}
