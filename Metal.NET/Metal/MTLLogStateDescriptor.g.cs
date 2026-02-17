namespace Metal.NET;

file class MTLLogStateDescriptorSelector
{
    public static readonly Selector SetBufferSize_ = Selector.Register("setBufferSize:");
    public static readonly Selector SetLevel_ = Selector.Register("setLevel:");
}

public class MTLLogStateDescriptor : IDisposable
{
    public MTLLogStateDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLLogStateDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLLogStateDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLLogStateDescriptor(nint value)
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

    public void SetBufferSize(nint bufferSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogStateDescriptorSelector.SetBufferSize_, bufferSize);
    }

    public void SetLevel(MTLLogLevel level)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogStateDescriptorSelector.SetLevel_, (nint)(uint)level);
    }

}
