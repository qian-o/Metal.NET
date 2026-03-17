namespace Metal.NET;

public class MTL4CommandQueueDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommandQueueDescriptor>
{
    #region INativeObject
    public static new MTL4CommandQueueDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommandQueueDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4CommandQueueDescriptor() : this(ObjectiveC.AllocInit(MTL4CommandQueueDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandQueueDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4CommandQueueDescriptorBindings.SetLabel, value);
    }

    public DispatchQueue FeedbackQueue
    {
        get => GetProperty(ref field, MTL4CommandQueueDescriptorBindings.FeedbackQueue);
        set => SetProperty(ref field, MTL4CommandQueueDescriptorBindings.SetFeedbackQueue, value);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandQueueDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4CommandQueueDescriptorBindings.SetLabel, value);
    }

    public DispatchQueue FeedbackQueue
    {
        get => GetProperty(ref field, MTL4CommandQueueDescriptorBindings.FeedbackQueue);
        set => SetProperty(ref field, MTL4CommandQueueDescriptorBindings.SetFeedbackQueue, value);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueDescriptorBindings.SetLabel, label.NativePtr);
    }

    public void SetFeedbackQueue(DispatchQueue feedbackQueue)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueDescriptorBindings.SetFeedbackQueue, feedbackQueue.NativePtr);
    }
}

file static class MTL4CommandQueueDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CommandQueueDescriptor");

    public static readonly Selector FeedbackQueue = "feedbackQueue";

    public static readonly Selector Label = "label";

    public static readonly Selector SetFeedbackQueue = "setFeedbackQueue:";

    public static readonly Selector SetLabel = "setLabel:";
}
