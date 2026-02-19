namespace Metal.NET;

public readonly struct MTLIOCommandQueueDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLIOCommandQueueDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIOCommandQueueDescriptorBindings.Class))
    {
    }

    public nuint MaxCommandBufferCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIOCommandQueueDescriptorBindings.MaxCommandBufferCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetMaxCommandBufferCount, value);
    }

    public nuint MaxCommandsInFlight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIOCommandQueueDescriptorBindings.MaxCommandsInFlight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetMaxCommandsInFlight, value);
    }

    public MTLIOPriority Priority
    {
        get => (MTLIOPriority)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueDescriptorBindings.Priority);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetPriority, (nint)value);
    }

    public MTLIOScratchBufferAllocator? ScratchBufferAllocator
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueDescriptorBindings.ScratchBufferAllocator);
            return ptr is not 0 ? new MTLIOScratchBufferAllocator(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetScratchBufferAllocator, value?.NativePtr ?? 0);
    }

    public MTLIOCommandQueueType Type
    {
        get => (MTLIOCommandQueueType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueDescriptorBindings.Type);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetType, (nint)value);
    }
}

file static class MTLIOCommandQueueDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIOCommandQueueDescriptor");

    public static readonly Selector MaxCommandBufferCount = Selector.Register("maxCommandBufferCount");

    public static readonly Selector MaxCommandsInFlight = Selector.Register("maxCommandsInFlight");

    public static readonly Selector Priority = Selector.Register("priority");

    public static readonly Selector ScratchBufferAllocator = Selector.Register("scratchBufferAllocator");

    public static readonly Selector SetMaxCommandBufferCount = Selector.Register("setMaxCommandBufferCount:");

    public static readonly Selector SetMaxCommandsInFlight = Selector.Register("setMaxCommandsInFlight:");

    public static readonly Selector SetPriority = Selector.Register("setPriority:");

    public static readonly Selector SetScratchBufferAllocator = Selector.Register("setScratchBufferAllocator:");

    public static readonly Selector SetType = Selector.Register("setType:");

    public static readonly Selector Type = Selector.Register("type");
}
