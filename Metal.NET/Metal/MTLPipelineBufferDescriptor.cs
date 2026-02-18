namespace Metal.NET;

public class MTLPipelineBufferDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPipelineBufferDescriptor");

    public MTLPipelineBufferDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLPipelineBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLPipelineBufferDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLMutability Mutability
    {
        get => (MTLMutability)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLPipelineBufferDescriptorSelector.Mutability));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPipelineBufferDescriptorSelector.SetMutability, (ulong)value);
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
