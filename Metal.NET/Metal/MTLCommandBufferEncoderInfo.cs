namespace Metal.NET;

public class MTLCommandBufferEncoderInfo(nint nativePtr) : NativeObject(nativePtr)
{

    public NSArray? DebugSignposts
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoSelector.DebugSignposts));
    }

    public MTLCommandEncoderErrorState ErrorState
    {
        get => (MTLCommandEncoderErrorState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoSelector.ErrorState);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoSelector.Label));
    }
}

file static class MTLCommandBufferEncoderInfoSelector
{
    public static readonly Selector DebugSignposts = Selector.Register("debugSignposts");

    public static readonly Selector ErrorState = Selector.Register("errorState");

    public static readonly Selector Label = Selector.Register("label");
}
