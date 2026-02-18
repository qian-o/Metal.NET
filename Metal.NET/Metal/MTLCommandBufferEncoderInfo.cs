namespace Metal.NET;

public partial class MTLCommandBufferEncoderInfo : NativeObject
{
    public MTLCommandBufferEncoderInfo(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? DebugSignposts
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoSelector.DebugSignposts);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLCommandEncoderErrorState ErrorState
    {
        get => (MTLCommandEncoderErrorState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoSelector.ErrorState);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLCommandBufferEncoderInfoSelector
{
    public static readonly Selector DebugSignposts = Selector.Register("debugSignposts");

    public static readonly Selector ErrorState = Selector.Register("errorState");

    public static readonly Selector Label = Selector.Register("label");
}
