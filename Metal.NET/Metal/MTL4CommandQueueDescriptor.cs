namespace Metal.NET;

public readonly struct MTL4CommandQueueDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4CommandQueueDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CommandQueueDescriptorBindings.Class))
    {
    }

    public nint FeedbackQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueDescriptorBindings.FeedbackQueue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueDescriptorBindings.SetFeedbackQueue, value);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTL4CommandQueueDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandQueueDescriptor");

    public static readonly Selector FeedbackQueue = Selector.Register("feedbackQueue");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetFeedbackQueue = Selector.Register("setFeedbackQueue:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
