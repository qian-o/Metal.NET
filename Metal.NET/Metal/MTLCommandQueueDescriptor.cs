namespace Metal.NET;

public class MTLCommandQueueDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCommandQueueDescriptor>
{
    public static MTLCommandQueueDescriptor Null { get; } = new(0, false);

    public static MTLCommandQueueDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLCommandQueueDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCommandQueueDescriptorBindings.Class), true)
    {
        GC.ReRegisterForFinalize(this);
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
