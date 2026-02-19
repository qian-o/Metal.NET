namespace Metal.NET;

public class MTLCommandQueueDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCommandQueueDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLCommandQueueDescriptorBindings.Class))
    {
    }

    public MTLLogState? LogState
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueDescriptorBindings.LogState);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLLogState(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueDescriptorBindings.SetLogState, value?.NativePtr ?? 0);
            field = value;
        }
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
