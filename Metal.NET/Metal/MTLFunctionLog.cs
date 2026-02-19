namespace Metal.NET;

public readonly struct MTLFunctionLog(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLFunctionLogDebugLocation? DebugLocation
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogBindings.DebugLocation);
            return ptr is not 0 ? new MTLFunctionLogDebugLocation(ptr) : default;
        }
    }

    public NSString? EncoderLabel
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogBindings.EncoderLabel);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public MTLFunction? Function
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogBindings.Function);
            return ptr is not 0 ? new MTLFunction(ptr) : default;
        }
    }

    public MTLFunctionLogType Type
    {
        get => (MTLFunctionLogType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogBindings.Type);
    }
}

file static class MTLFunctionLogBindings
{
    public static readonly Selector DebugLocation = Selector.Register("debugLocation");

    public static readonly Selector EncoderLabel = Selector.Register("encoderLabel");

    public static readonly Selector Function = Selector.Register("function");

    public static readonly Selector Type = Selector.Register("type");
}
