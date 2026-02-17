namespace Metal.NET;

public class MTLCommandQueueDescriptor : IDisposable
{
    public MTLCommandQueueDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCommandQueueDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLLogState LogState
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueDescriptorSelector.LogState));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueDescriptorSelector.SetLogState, value.NativePtr);
    }

    public nuint MaxCommandBufferCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCommandQueueDescriptorSelector.MaxCommandBufferCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueDescriptorSelector.SetMaxCommandBufferCount, (nuint)value);
    }

    public static implicit operator nint(MTLCommandQueueDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCommandQueueDescriptor(nint value)
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

file class MTLCommandQueueDescriptorSelector
{
    public static readonly Selector LogState = Selector.Register("logState");

    public static readonly Selector SetLogState = Selector.Register("setLogState:");

    public static readonly Selector MaxCommandBufferCount = Selector.Register("maxCommandBufferCount");

    public static readonly Selector SetMaxCommandBufferCount = Selector.Register("setMaxCommandBufferCount:");
}
