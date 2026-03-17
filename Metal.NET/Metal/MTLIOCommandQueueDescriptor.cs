namespace Metal.NET;

public class MTLIOCommandQueueDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIOCommandQueueDescriptor>
{
    #region INativeObject
    public static new MTLIOCommandQueueDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIOCommandQueueDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLIOCommandQueueDescriptor() : this(ObjectiveC.AllocInit(MTLIOCommandQueueDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
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
        get => GetProperty(ref field, MTLIOCommandQueueDescriptorBindings.ScratchBufferAllocator);
        set => SetProperty(ref field, MTLIOCommandQueueDescriptorBindings.SetScratchBufferAllocator, value);
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
        get => GetProperty(ref field, MTLIOCommandQueueDescriptorBindings.ScratchBufferAllocator);
        set => SetProperty(ref field, MTLIOCommandQueueDescriptorBindings.SetScratchBufferAllocator, value);
    }

    public void SetMaxCommandBufferCount(nuint maxCommandBufferCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetMaxCommandBufferCount, maxCommandBufferCount);
    }

    public void SetPriority(MTLIOPriority priority)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetPriority, (nint)priority);
    }

    public void SetType(MTLIOCommandQueueType type)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetType, (nint)type);
    }

    public void SetMaxCommandsInFlight(nuint maxCommandsInFlight)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetMaxCommandsInFlight, maxCommandsInFlight);
    }

    public void SetScratchBufferAllocator(MTLIOScratchBufferAllocator scratchBufferAllocator)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetScratchBufferAllocator, scratchBufferAllocator.NativePtr);
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
