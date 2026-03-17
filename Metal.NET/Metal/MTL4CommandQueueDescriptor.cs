namespace Metal.NET;

/// <summary>
/// Groups together parameters for the creation of a new command queue.
/// </summary>
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

    #region Instance Properties - Properties

    /// <summary>
    /// Assigns a dispatch queue to which Metal submits feedback notification blocks.
    /// </summary>
    public DispatchQueue FeedbackQueue
    {
        get => GetProperty(ref field, MTL4CommandQueueDescriptorBindings.FeedbackQueue);
        set => SetProperty(ref field, MTL4CommandQueueDescriptorBindings.SetFeedbackQueue, value);
    }

    /// <summary>
    /// Assigns an optional label to the command queue instance for debugging purposes.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandQueueDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4CommandQueueDescriptorBindings.SetLabel, value);
    }
    #endregion
}

file static class MTL4CommandQueueDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CommandQueueDescriptor");

    public static readonly Selector FeedbackQueue = "feedbackQueue";

    public static readonly Selector Label = "label";

    public static readonly Selector SetFeedbackQueue = "setFeedbackQueue:";

    public static readonly Selector SetLabel = "setLabel:";
}
