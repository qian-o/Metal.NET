namespace Metal.NET;

public class MTL4CommandQueueDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4CommandQueueDescriptor>
{
    public static MTL4CommandQueueDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4CommandQueueDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4CommandQueueDescriptor() : this(ObjectiveC.AllocInit(MTL4CommandQueueDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public DispatchQueue FeedbackQueue
    {
        get => ObjectiveC.MsgSendPtr(NativePtr, MTL4CommandQueueDescriptorBindings.FeedbackQueue);
        set => ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueDescriptorBindings.SetFeedbackQueue, value);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandQueueDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4CommandQueueDescriptorBindings.SetLabel, value);
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
