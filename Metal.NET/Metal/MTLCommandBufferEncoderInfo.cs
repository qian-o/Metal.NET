namespace Metal.NET;

public class MTLCommandBufferEncoderInfo(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCommandBufferEncoderInfo>
{
    #region INativeObject
    public static new MTLCommandBufferEncoderInfo Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCommandBufferEncoderInfo New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString[] DebugSignposts
    {
        get => GetArrayProperty<NSString>(MTLCommandBufferEncoderInfoBindings.DebugSignposts);
    }

    public MTLCommandEncoderErrorState ErrorState
    {
        get => (MTLCommandEncoderErrorState)ObjectiveC.MsgSendLong(NativePtr, MTLCommandBufferEncoderInfoBindings.ErrorState);
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
