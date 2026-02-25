namespace Metal.NET;

public class MTL4CommandQueueDescriptor(nint nativePtr, bool ownsReference, bool allowGCRelease) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTL4CommandQueueDescriptor>
{
    public static MTL4CommandQueueDescriptor Null { get; } = new(0, false, false);

    public static MTL4CommandQueueDescriptor Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public MTL4CommandQueueDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CommandQueueDescriptorBindings.Class), true, true)
    {
    }

    public nint FeedbackQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueDescriptorBindings.FeedbackQueue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueDescriptorBindings.SetFeedbackQueue, value);
    }

    public NSString Label
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
