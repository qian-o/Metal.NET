namespace Metal.NET;

public class MTL4CommandQueueDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandQueueDescriptor");

    public MTL4CommandQueueDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4CommandQueueDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4CommandQueueDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nint FeedbackQueue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueDescriptorSelector.FeedbackQueue);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueDescriptorSelector.SetFeedbackQueue, value);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandQueueDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandQueueDescriptorSelector.SetLabel, value.NativePtr);
    }

    public static implicit operator nint(MTL4CommandQueueDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommandQueueDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTL4CommandQueueDescriptorSelector
{
    public static readonly Selector FeedbackQueue = Selector.Register("feedbackQueue");

    public static readonly Selector SetFeedbackQueue = Selector.Register("setFeedbackQueue:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
