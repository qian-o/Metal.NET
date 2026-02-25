namespace Metal.NET;

public class MTLCommandBufferEncoderInfo(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCommandBufferEncoderInfo>
{
    public static MTLCommandBufferEncoderInfo Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public NSString[] DebugSignposts
    {
        get => GetArrayProperty<NSString>(MTLCommandBufferEncoderInfoBindings.DebugSignposts);
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
