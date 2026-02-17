using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLBuffer_Selectors
{
    internal static readonly Selector newRemoteBufferViewForDevice_ = Selector.Register("newRemoteBufferViewForDevice:");
    internal static readonly Selector newTensor_offset_error_ = Selector.Register("newTensor:offset:error:");
    internal static readonly Selector newTexture_offset_bytesPerRow_ = Selector.Register("newTexture:offset:bytesPerRow:");
    internal static readonly Selector removeAllDebugMarkers = Selector.Register("removeAllDebugMarkers");
}

public class MTLBuffer : IDisposable
{
    public nint NativePtr { get; }

    public MTLBuffer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLBuffer o) => o.NativePtr;
    public static implicit operator MTLBuffer(nint ptr) => new MTLBuffer(ptr);

    ~MTLBuffer() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public MTLBuffer NewRemoteBufferViewForDevice(MTLDevice device)
    {
        var __r = new MTLBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBuffer_Selectors.newRemoteBufferViewForDevice_, device.NativePtr));
        return __r;
    }

    public MTLTensor NewTensor(MTLTensorDescriptor descriptor, nuint offset, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = new MTLTensor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBuffer_Selectors.newTensor_offset_error_, descriptor.NativePtr, (nint)offset, out __errorPtr));
        error = new NSError(__errorPtr);
        return __r;
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow)
    {
        var __r = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBuffer_Selectors.newTexture_offset_bytesPerRow_, descriptor.NativePtr, (nint)offset, (nint)bytesPerRow));
        return __r;
    }

    public void RemoveAllDebugMarkers()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBuffer_Selectors.removeAllDebugMarkers);
    }

}
