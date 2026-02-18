namespace Metal.NET;

public partial class MTLCommandQueueDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCommandQueueDescriptor");

    public MTLCommandQueueDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLLogState? LogState
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueDescriptorSelector.LogState);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueDescriptorSelector.SetLogState, value?.NativePtr ?? 0);
    }

    public nuint MaxCommandBufferCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCommandQueueDescriptorSelector.MaxCommandBufferCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueDescriptorSelector.SetMaxCommandBufferCount, value);
    }
}

file static class MTLCommandQueueDescriptorSelector
{
    public static readonly Selector LogState = Selector.Register("logState");

    public static readonly Selector MaxCommandBufferCount = Selector.Register("maxCommandBufferCount");

    public static readonly Selector SetLogState = Selector.Register("setLogState:");

    public static readonly Selector SetMaxCommandBufferCount = Selector.Register("setMaxCommandBufferCount:");
}
