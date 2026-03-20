namespace Metal.NET;

public class MTLFunctionLog(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionLog>
{
    #region INativeObject
    public static new MTLFunctionLog Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionLog New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionLogType Type
    {
        get => (MTLFunctionLogType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionLogBindings.Type);
    }

    public NSString EncoderLabel
    {
        get => GetProperty(ref field, MTLFunctionLogBindings.EncoderLabel);
    }

    public MTLFunction Function
    {
        get => GetProperty(ref field, MTLFunctionLogBindings.Function);
    }

    public MTLFunctionLogDebugLocation DebugLocation
    {
        get => GetProperty(ref field, MTLFunctionLogBindings.DebugLocation);
    }
}

file static class MTLFunctionLogBindings
{
    public static readonly Selector DebugLocation = "debugLocation";

    public static readonly Selector EncoderLabel = "encoderLabel";

    public static readonly Selector Function = "function";

    public static readonly Selector Type = "type";
}
