using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTensor_Selectors
{
    internal static readonly Selector getBytes_strides_sliceOrigin_sliceDimensions_ = Selector.Register("getBytes:strides:sliceOrigin:sliceDimensions:");
    internal static readonly Selector replaceSliceOrigin_sliceDimensions_bytes_strides_ = Selector.Register("replaceSliceOrigin:sliceDimensions:bytes:strides:");
}

public class MTLTensor : IDisposable
{
    public nint NativePtr { get; }

    public MTLTensor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTensor o) => o.NativePtr;
    public static implicit operator MTLTensor(nint ptr) => new MTLTensor(ptr);

    ~MTLTensor() => Release();

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

    public void GetBytes(nint bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensor_Selectors.getBytes_strides_sliceOrigin_sliceDimensions_, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr);
    }

    public void ReplaceSliceOrigin(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, nint bytes, MTLTensorExtents strides)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensor_Selectors.replaceSliceOrigin_sliceDimensions_bytes_strides_, sliceOrigin.NativePtr, sliceDimensions.NativePtr, bytes, strides.NativePtr);
    }

}
