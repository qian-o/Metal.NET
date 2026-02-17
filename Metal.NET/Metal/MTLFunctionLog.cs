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

    public MTLFunctionLogDebugLocation DebugLocation => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.DebugLocation));

    public NSString EncoderLabel => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.EncoderLabel));

    public MTLFunction Function => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.Function));

    public MTLFunctionLogType Type => (MTLFunctionLogType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFunctionLogSelector.Type));

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
}

file class MTLFunctionLogSelector
{
    public static readonly Selector DebugLocation = Selector.Register("debugLocation");

    public static readonly Selector EncoderLabel = Selector.Register("encoderLabel");

    public static readonly Selector Function = Selector.Register("function");

    public static readonly Selector Type = Selector.Register("type");
}
