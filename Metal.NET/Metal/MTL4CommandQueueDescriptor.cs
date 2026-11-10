namespace Metal.NET;

public readonly struct MTL4CommandQueueDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4CommandQueueDescriptor value) => new(value.NativePtr);

    public MTL4CommandQueueDescriptor() : this(ObjectiveC.AllocInit(MTL4CommandQueueDescriptorBindings.Class))
    {
    }

    public MTL4CommandQueueDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandQueueDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueDescriptorBindings.SetLabel, value.NativePtr);
    }

    public DispatchQueue FeedbackQueue
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandQueueDescriptorBindings.FeedbackQueue));
        set => ObjectiveC.MsgSend(NativePtr, MTL4CommandQueueDescriptorBindings.SetFeedbackQueue, value.NativePtr);
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
