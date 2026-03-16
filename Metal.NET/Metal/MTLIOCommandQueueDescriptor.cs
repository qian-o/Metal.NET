namespace Metal.NET;

/// <summary>A configuration template you use to create a new input/output command queue.</summary>
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

    #region Configuring the input/output command queue - Properties

    /// <summary>Configures the priority for a new input/output command queue.</summary>
    public MTLIOPriority Priority
    {
        get => (MTLIOPriority)ObjectiveC.MsgSendLong(NativePtr, MTLIOCommandQueueDescriptorBindings.Priority);
        set => ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetPriority, (nint)value);
    }

    /// <summary>Configures the queue type for a new input/output command queue.</summary>
    public MTLIOCommandQueueType Type
    {
        get => (MTLIOCommandQueueType)ObjectiveC.MsgSendLong(NativePtr, MTLIOCommandQueueDescriptorBindings.Type);
        set => ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetType, (nint)value);
    }

    /// <summary>Sets the largest number of individual commands that an input/output command queue can run at a time.</summary>
    public nuint MaxCommandsInFlight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIOCommandQueueDescriptorBindings.MaxCommandsInFlight);
        set => ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetMaxCommandsInFlight, value);
    }

    /// <summary>Sets the largest number of outstanding input/output command buffers a queue can have at any point in time.</summary>
    public nuint MaxCommandBufferCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIOCommandQueueDescriptorBindings.MaxCommandBufferCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIOCommandQueueDescriptorBindings.SetMaxCommandBufferCount, value);
    }
    #endregion

    #region Providing your own a scratch buffer - Properties

    /// <summary>An optional memory allocator that you implement to manage the scratch memory that an input/output command queue requests.</summary>
    public MTLIOScratchBufferAllocator ScratchBufferAllocator
    {
        get => GetProperty(ref field, MTLIOCommandQueueDescriptorBindings.ScratchBufferAllocator);
        set => SetProperty(ref field, MTLIOCommandQueueDescriptorBindings.SetScratchBufferAllocator, value);
    }
    #endregion
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
