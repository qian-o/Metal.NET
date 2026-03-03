namespace Metal.NET;

public class MTLCommandBufferEncoderInfo(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLCommandBufferEncoderInfo>
{
    public static new MTLCommandBufferEncoderInfo Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCommandBufferEncoderInfo Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public NSString[] DebugSignposts
    {
        get => GetArrayProperty<NSString>(MTLCommandBufferEncoderInfoBindings.DebugSignposts);
    }

    public MTLCommandEncoderErrorState ErrorState
    {
        get => (MTLCommandEncoderErrorState)ObjectiveCRuntime.MsgSendLong(NativePtr, MTLCommandBufferEncoderInfoBindings.ErrorState);
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
