namespace Metal.NET;

public class MTLLogStateDescriptor : IDisposable
{
    public MTLLogStateDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetBufferSize(int bufferSize)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogStateDescriptorSelector.SetBufferSize, bufferSize);
    }

    public void SetLevel(MTLLogLevel level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogStateDescriptorSelector.SetLevel, (nint)(uint)level);
    }

}

file class MTLLogStateDescriptorSelector
{
    public static readonly Selector SetBufferSize = Selector.Register("setBufferSize:");

    public static readonly Selector SetLevel = Selector.Register("setLevel:");
}
