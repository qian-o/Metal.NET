namespace Metal.NET;

public class MTLCommandQueueDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCommandQueueDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCommandQueueDescriptorSelector.Class))
    {
    }

    public MTLLogState? LogState
    {
        get => GetNullableObject<MTLLogState>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueDescriptorSelector.LogState));
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
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLCommandQueueDescriptor");

    public static readonly Selector LogState = Selector.Register("logState");

    public static readonly Selector MaxCommandBufferCount = Selector.Register("maxCommandBufferCount");

    public static readonly Selector SetLogState = Selector.Register("setLogState:");

    public static readonly Selector SetMaxCommandBufferCount = Selector.Register("setMaxCommandBufferCount:");
}
