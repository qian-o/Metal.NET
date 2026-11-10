namespace Metal.NET;

public readonly struct MTLCommandBufferEncoderInfo(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLCommandBufferEncoderInfo value) => new(value.NativePtr);

    public MTLCommandBufferEncoderInfo Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferEncoderInfoBindings.Label));
    }

    public NSArray<NSString> DebugSignposts
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandBufferEncoderInfoBindings.DebugSignposts));
    }

    public MTLCommandEncoderErrorState ErrorState
    {
        get => (MTLCommandEncoderErrorState)ObjectiveC.MsgSendLong(NativePtr, MTLCommandBufferEncoderInfoBindings.ErrorState);
    }
}

file static class MTLCommandBufferEncoderInfoBindings
{
    public static readonly Selector DebugSignposts = "debugSignposts";

    public static readonly Selector ErrorState = "errorState";

    public static readonly Selector Label = "label";
}
