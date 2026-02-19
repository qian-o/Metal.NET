namespace Metal.NET;

public readonly struct MTLCommandBufferEncoderInfo(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public NSArray? DebugSignposts
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoBindings.DebugSignposts);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public MTLCommandEncoderErrorState ErrorState
    {
        get => (MTLCommandEncoderErrorState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoBindings.ErrorState);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }
}

file static class MTLCommandBufferEncoderInfoBindings
{
    public static readonly Selector DebugSignposts = Selector.Register("debugSignposts");

    public static readonly Selector ErrorState = Selector.Register("errorState");

    public static readonly Selector Label = Selector.Register("label");
}
