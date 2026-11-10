namespace Metal.NET;

public readonly struct MTLIOCommandQueueDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLIOCommandQueueDescriptor value) => new(value.NativePtr);

    public MTLIOCommandQueueDescriptor() : this(ObjectiveC.AllocInit(MTLIOCommandQueueDescriptorBindings.Class))
    {
    }

    public MTLIOCommandQueueDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint MaxCommandBufferCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIOCommandQueueDescriptorBindings.MaxCommandBufferCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetMaxCommandBufferCount, value);
    }

    public MTLIOPriority Priority
    {
        get => (MTLIOPriority)ObjectiveC.MsgSendLong(NativePtr, MTLIOCommandQueueDescriptorBindings.Priority);
        set => ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetPriority, (nint)value);
    }

    public MTLIOCommandQueueType Type
    {
        get => (MTLIOCommandQueueType)ObjectiveC.MsgSendLong(NativePtr, MTLIOCommandQueueDescriptorBindings.Type);
        set => ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetType, (nint)value);
    }

    public nuint MaxCommandsInFlight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIOCommandQueueDescriptorBindings.MaxCommandsInFlight);
        set => ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetMaxCommandsInFlight, value);
    }

    public MTLIOScratchBufferAllocator ScratchBufferAllocator
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIOCommandQueueDescriptorBindings.ScratchBufferAllocator));
        set => ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetScratchBufferAllocator, value.NativePtr);
    }
}

file static class MTLIOCommandQueueDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLIOCommandQueueDescriptor");

    public static readonly Selector MaxCommandBufferCount = "maxCommandBufferCount";

    public static readonly Selector MaxCommandsInFlight = "maxCommandsInFlight";

    public static readonly Selector Priority = "priority";

    public static readonly Selector ScratchBufferAllocator = "scratchBufferAllocator";

    public static readonly Selector SetMaxCommandBufferCount = "setMaxCommandBufferCount:";

    public static readonly Selector SetMaxCommandsInFlight = "setMaxCommandsInFlight:";

    public static readonly Selector SetPriority = "setPriority:";

    public static readonly Selector SetScratchBufferAllocator = "setScratchBufferAllocator:";

    public static readonly Selector SetType = "setType:";

    public static readonly Selector Type = "type";
}
