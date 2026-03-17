namespace Metal.NET;

/// <summary>
/// A log entry a Metal device generates when the it runs a command buffer.
/// </summary>
public class MTLFunctionLog(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionLog>
{
    #region INativeObject
    public static new MTLFunctionLog Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionLog New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Getting the log messsage - Properties

    /// <summary>
    /// The type of message that was logged.
    /// </summary>
    public MTLFunctionLogType Type
    {
        get => (MTLFunctionLogType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionLogBindings.Type);
    }
    #endregion

    #region Getting execution details - Properties

    /// <summary>
    /// If known, the location of the logging command within a shader source file.
    /// </summary>
    public MTLFunctionLogDebugLocation DebugLocation
    {
        get => GetProperty(ref field, MTLFunctionLogBindings.DebugLocation);
    }

    /// <summary>
    /// The label for the encoder that logged the message.
    /// </summary>
    public NSString EncoderLabel
    {
        get => GetProperty(ref field, MTLFunctionLogBindings.EncoderLabel);
    }

    /// <summary>
    /// When known, the function object corresponding to the logged message.
    /// </summary>
    public MTLFunction Function
    {
        get => GetProperty(ref field, MTLFunctionLogBindings.Function);
    }
    #endregion
}

file static class MTLFunctionLogBindings
{
    public static readonly Selector DebugLocation = "debugLocation";

    public static readonly Selector EncoderLabel = "encoderLabel";

    public static readonly Selector Function = "function";

    public static readonly Selector Type = "type";
}
