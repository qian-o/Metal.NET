namespace Metal.NET;

file class MTL4ArgumentTableSelector
{
    public static readonly Selector SetAddress_bindingIndex_ = Selector.Register("setAddress:bindingIndex:");
    public static readonly Selector SetAddress_stride_bindingIndex_ = Selector.Register("setAddress:stride:bindingIndex:");
}

public class MTL4ArgumentTable : IDisposable
{
    public MTL4ArgumentTable(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4ArgumentTable()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4ArgumentTable value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4ArgumentTable(nint value)
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

    public void SetAddress(nuint gpuAddress, nuint bindingIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableSelector.SetAddress_bindingIndex_, (nint)gpuAddress, (nint)bindingIndex);
    }

    public void SetAddress(nuint gpuAddress, nuint stride, nuint bindingIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableSelector.SetAddress_stride_bindingIndex_, (nint)gpuAddress, (nint)stride, (nint)bindingIndex);
    }

}
