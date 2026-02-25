namespace Metal.NET;

public class MTLFunctionLog(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionLog>
{
    public static MTLFunctionLog Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLFunctionLogDebugLocation DebugLocation
    {
        get => GetProperty(ref field, MTLFunctionLogBindings.DebugLocation);
    }

    public NSString EncoderLabel
    {
        get => GetProperty(ref field, MTLFunctionLogBindings.EncoderLabel);
    }

    public MTLFunction Function
    {
        get => GetProperty(ref field, MTLFunctionLogBindings.Function);
    }

    public MTLFunctionLogType Type
    {
        get => (MTLFunctionLogType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogBindings.Type);
    }
}

file static class MTLFunctionLogBindings
{
    public static readonly Selector DebugLocation = "debugLocation";

    public static readonly Selector EncoderLabel = "encoderLabel";

    public static readonly Selector Function = "function";

    public static readonly Selector Type = "type";
}
