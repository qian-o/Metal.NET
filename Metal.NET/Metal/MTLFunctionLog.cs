namespace Metal.NET;

public class MTLFunctionLog : IDisposable
{
    public MTLFunctionLog(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFunctionLog()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionLog value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionLog(nint value)
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

    public MTLFunctionLogDebugLocation DebugLocation
    {
        get => new MTLFunctionLogDebugLocation(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.DebugLocation));
    }

    public NSString EncoderLabel
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.EncoderLabel));
    }

    public MTLFunction Function
    {
        get => new MTLFunction(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.Function));
    }

    public MTLFunctionLogType Type
    {
        get => (MTLFunctionLogType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFunctionLogSelector.Type));
    }

}

file class MTLFunctionLogSelector
{
    public static readonly Selector DebugLocation = Selector.Register("debugLocation");

    public static readonly Selector EncoderLabel = Selector.Register("encoderLabel");

    public static readonly Selector Function = Selector.Register("function");

    public static readonly Selector Type = Selector.Register("type");
}
