namespace Metal.NET;

public class MTLTensor : IDisposable
{
    public MTLTensor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void GetBytes(int bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorSelector.GetBytesStridesSliceOriginSliceDimensions, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr);
    }

    public void ReplaceSliceOrigin(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, int bytes, MTLTensorExtents strides)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTensorSelector.ReplaceSliceOriginSliceDimensionsBytesStrides, sliceOrigin.NativePtr, sliceDimensions.NativePtr, bytes, strides.NativePtr);
    }

}

file class MTLTensorSelector
{
    public static readonly Selector GetBytesStridesSliceOriginSliceDimensions = Selector.Register("getBytes:strides:sliceOrigin:sliceDimensions:");
    public static readonly Selector ReplaceSliceOriginSliceDimensionsBytesStrides = Selector.Register("replaceSliceOrigin:sliceDimensions:bytes:strides:");
}
