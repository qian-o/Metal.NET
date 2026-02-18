namespace Metal.NET;

public partial class MTLIOCommandQueueDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIOCommandQueueDescriptor");

    public MTLIOCommandQueueDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint MaxCommandBufferCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIOCommandQueueDescriptorSelector.MaxCommandBufferCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetMaxCommandBufferCount, value);
    }

    public nuint MaxCommandsInFlight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIOCommandQueueDescriptorSelector.MaxCommandsInFlight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetMaxCommandsInFlight, value);
    }

    public MTLIOPriority Priority
    {
        get => (MTLIOPriority)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueDescriptorSelector.Priority);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetPriority, (nint)value);
    }

    public MTLIOScratchBufferAllocator? ScratchBufferAllocator
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueDescriptorSelector.ScratchBufferAllocator);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetScratchBufferAllocator, value?.NativePtr ?? 0);
    }

    public MTLIOCommandQueueType Type
    {
        get => (MTLIOCommandQueueType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOCommandQueueDescriptorSelector.Type);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandQueueDescriptorSelector.SetType, (nint)value);
    }
}

file static class MTLIOCommandQueueDescriptorSelector
{
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
