namespace Metal.NET;

file class MTLTensorExtentsSelector
{
    public static readonly Selector ExtentAtDimensionIndex_ = Selector.Register("extentAtDimensionIndex:");
}

public class MTLTensorExtents : IDisposable
{
    public MTLTensorExtents(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLTensorExtents()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTensorExtents value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTensorExtents(nint value)
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

    public nint ExtentAtDimensionIndex(nuint dimensionIndex)
    {
        var result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTensorExtentsSelector.ExtentAtDimensionIndex_, (nint)dimensionIndex);

        return result;
    }

}
