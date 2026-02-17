namespace Metal.NET;

public class MTLPipelineBufferDescriptor : IDisposable
{
    public MTLPipelineBufferDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLPipelineBufferDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLMutability Mutability
    {
        get => (MTLMutability)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLPipelineBufferDescriptorSelector.Mutability));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPipelineBufferDescriptorSelector.SetMutability, (uint)value);
    }

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

}

file class MTLPipelineBufferDescriptorSelector
{
    public static readonly Selector Mutability = Selector.Register("mutability");

    public static readonly Selector SetMutability = Selector.Register("setMutability:");
}
