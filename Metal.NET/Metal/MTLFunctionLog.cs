namespace Metal.NET;

public class MTLFunctionLog(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionLogDebugLocation? DebugLocation
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogBindings.DebugLocation);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLFunctionLogDebugLocation(ptr);
            }

            return field;
        }
    }

    public NSString? EncoderLabel
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogBindings.EncoderLabel);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
    }

    public MTLFunction? Function
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogBindings.Function);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLFunction(ptr);
            }

            return field;
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
