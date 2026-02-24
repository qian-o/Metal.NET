namespace Metal.NET;

public class MTLIOCommandQueueDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLIOCommandQueueDescriptor>
{
    public static MTLIOCommandQueueDescriptor Create(nint nativePtr) => new(nativePtr);

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

    public MTLIOScratchBufferAllocator ScratchBufferAllocator
    {
        get => GetProperty(ref field, MTLIOCommandQueueDescriptorBindings.ScratchBufferAllocator);
        set => SetProperty(ref field, MTLIOCommandQueueDescriptorBindings.SetScratchBufferAllocator, value);
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
