namespace Metal.NET;

public class MTLCommandQueueDescriptor(nint nativePtr, bool ownsReference, bool allowGCRelease) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLCommandQueueDescriptor>
{
    public static MTLCommandQueueDescriptor Null { get; } = new(0, false, false);

    public static MTLCommandQueueDescriptor Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public MTLCommandQueueDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCommandQueueDescriptorBindings.Class), true, true)
    {
    }

    public MTLLogState LogState
    {
        get => GetProperty(ref field, MTLCommandQueueDescriptorBindings.LogState);
        set => SetProperty(ref field, MTLCommandQueueDescriptorBindings.SetLogState, value);
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

    public static readonly Selector LogState = "logState";

    public static readonly Selector MaxCommandBufferCount = "maxCommandBufferCount";

    public static readonly Selector SetLogState = "setLogState:";

    public static readonly Selector SetMaxCommandBufferCount = "setMaxCommandBufferCount:";
}
