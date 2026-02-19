namespace Metal.NET;

public class MTLFunctionLogDebugLocation(nint nativePtr) : NativeObject(nativePtr)
{
    public nuint Column
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Column);
    }

    public NSString? FunctionName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogDebugLocationBindings.FunctionName);

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

    public nuint Line
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Line);
    }

    public NSURL? URL
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogDebugLocationBindings.URL);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSURL(ptr);
            }

            return field;
        }
    }
}

file static class MTLFunctionLogDebugLocationBindings
{
    public static readonly Selector Column = Selector.Register("column");

    public static readonly Selector FunctionName = Selector.Register("functionName");

    public static readonly Selector Line = Selector.Register("line");

    public static readonly Selector URL = Selector.Register("URL");
}
