namespace Metal.NET;

public partial class MTLCommandQueueDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCommandQueueDescriptor>
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

    public nuint MaxCommandBufferCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLCommandQueueDescriptorBindings.MaxCommandBufferCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandQueueDescriptorBindings.SetMaxCommandBufferCount, value);
    }

    public MTLLogState LogState
    {
        get => GetProperty(ref field, MTLCommandQueueDescriptorBindings.LogState);
        set => SetProperty(ref field, MTLCommandQueueDescriptorBindings.SetLogState, value);
    }
}

file static class MTLCommandQueueDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLCommandQueueDescriptor");

    public static readonly Selector LogState = "logState";

    public static readonly Selector MaxCommandBufferCount = "maxCommandBufferCount";

    public static readonly Selector SetLogState = "setLogState:";

    public static readonly Selector SetMaxCommandBufferCount = "setMaxCommandBufferCount:";
}
