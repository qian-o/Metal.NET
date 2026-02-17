namespace Metal.NET;

file class MTLTensorSelector
{
    public static readonly Selector GetBytes_strides_sliceOrigin_sliceDimensions_ = Selector.Register("getBytes:strides:sliceOrigin:sliceDimensions:");
    public static readonly Selector ReplaceSliceOrigin_sliceDimensions_bytes_strides_ = Selector.Register("replaceSliceOrigin:sliceDimensions:bytes:strides:");
}

public class MTLTensor : IDisposable
{
    public MTLTensor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLTensor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTensor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTensor(nint value)
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

    public void GetBytes(nint bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorSelector.GetBytes_strides_sliceOrigin_sliceDimensions_, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr);
    }

    public void ReplaceSliceOrigin(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, nint bytes, MTLTensorExtents strides)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorSelector.ReplaceSliceOrigin_sliceDimensions_bytes_strides_, sliceOrigin.NativePtr, sliceDimensions.NativePtr, bytes, strides.NativePtr);
    }

}
