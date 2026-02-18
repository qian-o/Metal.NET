namespace Metal.NET;

public class MTLFunctionLog(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLFunctionLogDebugLocation? DebugLocation
    {
        get => GetNullableObject<MTLFunctionLogDebugLocation>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.DebugLocation));
    }

    public NSString? EncoderLabel
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.EncoderLabel));
    }

    public MTLFunction? Function
    {
        get => GetNullableObject<MTLFunction>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogSelector.Function));
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
