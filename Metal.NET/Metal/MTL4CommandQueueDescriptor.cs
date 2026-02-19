namespace Metal.NET;

public class MTL4CommandQueueDescriptor(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTL4CommandQueueDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CommandQueueDescriptorBindings.Class), true)
    {
    }

    public nint FeedbackQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueDescriptorBindings.FeedbackQueue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueDescriptorBindings.SetFeedbackQueue, value);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTL4CommandQueueDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4CommandQueueDescriptorBindings.SetLabel, value);
    }
}

file static class MTL4CommandQueueDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandQueueDescriptor");

    public static readonly Selector FeedbackQueue = "feedbackQueue";

    public static readonly Selector Label = "label";

    public static readonly Selector SetFeedbackQueue = "setFeedbackQueue:";

    public static readonly Selector SetLabel = "setLabel:";
}
