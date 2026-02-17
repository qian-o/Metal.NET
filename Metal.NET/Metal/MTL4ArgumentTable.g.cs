namespace Metal.NET;

public class MTL4ArgumentTable : IDisposable
{
    public MTL4ArgumentTable(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetAddress(uint gpuAddress, uint bindingIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableSelector.SetAddressBindingIndex, (nint)gpuAddress, (nint)bindingIndex);
    }

    public void SetAddress(uint gpuAddress, uint stride, uint bindingIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableSelector.SetAddressStrideBindingIndex, (nint)gpuAddress, (nint)stride, (nint)bindingIndex);
    }

}

file class MTL4ArgumentTableSelector
{
    public static readonly Selector SetAddressBindingIndex = Selector.Register("setAddress:bindingIndex:");
    public static readonly Selector SetAddressStrideBindingIndex = Selector.Register("setAddress:stride:bindingIndex:");
}
