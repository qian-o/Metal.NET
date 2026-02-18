namespace Metal.NET;

public partial class MTL4CommandQueueDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandQueueDescriptor");

    public MTL4CommandQueueDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public nint FeedbackQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueDescriptorSelector.FeedbackQueue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueDescriptorSelector.SetFeedbackQueue, value);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueDescriptorSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTL4CommandQueueDescriptorSelector
{
    public static readonly Selector FeedbackQueue = Selector.Register("feedbackQueue");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetFeedbackQueue = Selector.Register("setFeedbackQueue:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
