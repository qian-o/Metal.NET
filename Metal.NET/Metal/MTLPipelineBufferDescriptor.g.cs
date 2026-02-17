namespace Metal.NET;

file class MTLPipelineBufferDescriptorSelector
{
    public static readonly Selector SetMutability_ = Selector.Register("setMutability:");
}

public class MTLPipelineBufferDescriptor : IDisposable
{
    public MTLPipelineBufferDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLPipelineBufferDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLPipelineBufferDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLPipelineBufferDescriptor(nint value)
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

    public void SetMutability(MTLMutability mutability)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPipelineBufferDescriptorSelector.SetMutability_, (nint)(uint)mutability);
    }

}
