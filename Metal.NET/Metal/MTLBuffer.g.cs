#nullable enable

namespace Metal.NET;

file class MTLBufferSelector
{
    public static readonly Selector NewRemoteBufferViewForDevice_ = Selector.Register("newRemoteBufferViewForDevice:");
    public static readonly Selector NewTensor_offset_error_ = Selector.Register("newTensor:offset:error:");
    public static readonly Selector NewTexture_offset_bytesPerRow_ = Selector.Register("newTexture:offset:bytesPerRow:");
    public static readonly Selector RemoveAllDebugMarkers = Selector.Register("removeAllDebugMarkers");
}

public class MTLBuffer : IDisposable
{
    public MTLBuffer(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var result = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBufferSelector.NewRemoteBufferViewForDevice_, device.NativePtr));

        return result;
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, nuint offset, out NSError? error)
    {
        nint errorPtr = 0;
        var result = new MTLTensor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBufferSelector.NewTensor_offset_error_, descriptor.NativePtr, (nint)offset, out errorPtr));
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBufferSelector.NewTexture_offset_bytesPerRow_, descriptor.NativePtr, (nint)offset, (nint)bytesPerRow));

        return result;
    }

    public void RemoveAllDebugMarkers()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBufferSelector.RemoveAllDebugMarkers);
    }

}
