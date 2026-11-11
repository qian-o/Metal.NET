namespace Metal.NET;

public readonly struct MTLCommandQueueDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLCommandQueueDescriptor value) => new(value.NativePtr);

    public MTLCommandQueueDescriptor() : this(ObjectiveC.AllocInit(MTLCommandQueueDescriptorBindings.Class))
    {
    }

    public MTLCommandQueueDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public nuint MaxCommandBufferCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLCommandQueueDescriptorBindings.MaxCommandBufferCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandQueueDescriptorBindings.SetMaxCommandBufferCount, value);
    }

    public MTLLogState LogState
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandQueueDescriptorBindings.LogState));
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandQueueDescriptorBindings.SetLogState, value.NativePtr);
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
