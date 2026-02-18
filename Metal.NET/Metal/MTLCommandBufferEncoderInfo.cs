namespace Metal.NET;

public class MTLCommandBufferEncoderInfo : IDisposable
{
    public MTLCommandBufferEncoderInfo(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLCommandBufferEncoderInfo()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray DebugSignposts
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoSelector.DebugSignposts));
    }

    public MTLCommandEncoderErrorState ErrorState
    {
        get => (MTLCommandEncoderErrorState)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLCommandBufferEncoderInfoSelector.ErrorState));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferEncoderInfoSelector.Label));
    }

    public static implicit operator nint(MTLCommandBufferEncoderInfo value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCommandBufferEncoderInfo(nint value)
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

file class MTLCommandBufferEncoderInfoSelector
{
    public static readonly Selector DebugSignposts = Selector.Register("debugSignposts");

    public static readonly Selector ErrorState = Selector.Register("errorState");

    public static readonly Selector Label = Selector.Register("label");
}
