namespace Metal.NET;

public partial class MTLFunctionLog : NativeObject
{
    public MTLFunctionLog(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLFunctionLogDebugLocation? DebugLocation
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.DebugLocation);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? EncoderLabel
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.EncoderLabel);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLFunction? Function
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.Function);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLFunctionLogType Type
    {
        get => (MTLFunctionLogType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogSelector.Type);
    }
}

file static class MTLFunctionLogSelector
{
    public static readonly Selector DebugLocation = Selector.Register("debugLocation");

    public static readonly Selector EncoderLabel = Selector.Register("encoderLabel");

    public static readonly Selector Function = Selector.Register("function");

    public static readonly Selector Type = Selector.Register("type");
}
