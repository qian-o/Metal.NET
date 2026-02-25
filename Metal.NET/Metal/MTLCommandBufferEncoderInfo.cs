namespace Metal.NET;

public class MTLCommandBufferEncoderInfo(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCommandBufferEncoderInfo>
{
    public static MTLCommandBufferEncoderInfo Create(nint nativePtr) => new(nativePtr, true);

    public static MTLCommandBufferEncoderInfo CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public NSArray DebugSignposts
    {
        get => GetProperty(ref field, MTLCommandBufferEncoderInfoBindings.DebugSignposts);
    }

    public MTLCommandEncoderErrorState ErrorState
    {
        get => (MTLCommandEncoderErrorState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoBindings.ErrorState);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLCommandBufferEncoderInfoBindings.Label);
    }
}

file static class MTLCommandBufferEncoderInfoBindings
{
    public static readonly Selector DebugSignposts = "debugSignposts";

    public static readonly Selector ErrorState = "errorState";

    public static readonly Selector Label = "label";
}
