namespace Metal.NET;

public readonly struct MTLFunctionLog(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLFunctionLog value) => new(value.NativePtr);

    public MTLFunctionLog Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLFunctionLogType Type
    {
        get => (MTLFunctionLogType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionLogBindings.Type);
    }

    public NSString EncoderLabel
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionLogBindings.EncoderLabel));
    }

    public MTLFunction Function
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionLogBindings.Function));
    }

    public MTLFunctionLogDebugLocation DebugLocation
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionLogBindings.DebugLocation));
    }
}

file static class MTLFunctionLogBindings
{
    public static readonly Selector DebugLocation = "debugLocation";

    public static readonly Selector EncoderLabel = "encoderLabel";

    public static readonly Selector Function = "function";

    public static readonly Selector Type = "type";
}
