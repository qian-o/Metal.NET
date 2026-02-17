namespace Metal.NET;

public class MTLIOCommandQueueDescriptor : IDisposable
{
    public MTLIOCommandQueueDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLIOCommandQueueDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIOCommandQueueDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIOCommandQueueDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLIOCommandQueueDescriptor");

    public MTLIOCommandQueueDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public nuint MaxCommandBufferCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIOCommandQueueDescriptorSelector.MaxCommandBufferCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetMaxCommandBufferCount, (nuint)value);
    }

    public nuint MaxCommandsInFlight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIOCommandQueueDescriptorSelector.MaxCommandsInFlight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetMaxCommandsInFlight, (nuint)value);
    }

    public MTLIOPriority Priority
    {
        get => (MTLIOPriority)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLIOCommandQueueDescriptorSelector.Priority));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetPriority, (uint)value);
    }

    public MTLIOScratchBufferAllocator ScratchBufferAllocator
    {
        get => new MTLIOScratchBufferAllocator(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueDescriptorSelector.ScratchBufferAllocator));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetScratchBufferAllocator, value.NativePtr);
    }

    public MTLIOCommandQueueType Type
    {
        get => (MTLIOCommandQueueType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLIOCommandQueueDescriptorSelector.Type));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetType, (uint)value);
    }

}

file class MTLIOCommandQueueDescriptorSelector
{
    public static readonly Selector MaxCommandBufferCount = Selector.Register("maxCommandBufferCount");

    public static readonly Selector SetMaxCommandBufferCount = Selector.Register("setMaxCommandBufferCount:");

    public static readonly Selector MaxCommandsInFlight = Selector.Register("maxCommandsInFlight");

    public static readonly Selector SetMaxCommandsInFlight = Selector.Register("setMaxCommandsInFlight:");

    public static readonly Selector Priority = Selector.Register("priority");

    public static readonly Selector SetPriority = Selector.Register("setPriority:");

    public static readonly Selector ScratchBufferAllocator = Selector.Register("scratchBufferAllocator");

    public static readonly Selector SetScratchBufferAllocator = Selector.Register("setScratchBufferAllocator:");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector SetType = Selector.Register("setType:");
}
