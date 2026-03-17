namespace Metal.NET;

/// <summary>
/// A configuration that customizes the behavior for a new command queue.
/// </summary>
public class MTLCommandQueueDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCommandQueueDescriptor>
{
    #region INativeObject
    public static new MTLCommandQueueDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCommandQueueDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLCommandQueueDescriptor() : this(ObjectiveC.AllocInit(MTLCommandQueueDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// The shader logging configuration that the command queue uses.
    /// </summary>
    public MTLLogState LogState
    {
        get => GetProperty(ref field, MTLCommandQueueDescriptorBindings.LogState);
        set => SetProperty(ref field, MTLCommandQueueDescriptorBindings.SetLogState, value);
    }

    /// <summary>
    /// An integer that sets the maximum number of uncompleted command buffers the queue can allow.
    /// </summary>
    public nuint MaxCommandBufferCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLCommandQueueDescriptorBindings.MaxCommandBufferCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandQueueDescriptorBindings.SetMaxCommandBufferCount, value);
    }
    #endregion
}

file static class MTLCommandQueueDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLCommandQueueDescriptor");

    public static readonly Selector LogState = "logState";

    public static readonly Selector MaxCommandBufferCount = "maxCommandBufferCount";

    public static readonly Selector SetLogState = "setLogState:";

    public static readonly Selector SetMaxCommandBufferCount = "setMaxCommandBufferCount:";
}
