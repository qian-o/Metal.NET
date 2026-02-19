namespace Metal.NET;

public readonly struct MTLCommandQueueDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLCommandQueueDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCommandQueueDescriptorBindings.Class))
    {
    }

    public MTLLogState? LogState
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueDescriptorBindings.LogState);
            return ptr is not 0 ? new MTLLogState(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueDescriptorBindings.SetLogState, value?.NativePtr ?? 0);
    }

    public nuint MaxCommandBufferCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCommandQueueDescriptorBindings.MaxCommandBufferCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueDescriptorBindings.SetMaxCommandBufferCount, value);
    }
}

file static class MTLCommandQueueDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCommandQueueDescriptor");

    public static readonly Selector LogState = Selector.Register("logState");

    public static readonly Selector MaxCommandBufferCount = Selector.Register("maxCommandBufferCount");

    public static readonly Selector SetLogState = Selector.Register("setLogState:");

    public static readonly Selector SetMaxCommandBufferCount = Selector.Register("setMaxCommandBufferCount:");
}
