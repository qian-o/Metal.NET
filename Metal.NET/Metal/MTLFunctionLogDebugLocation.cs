namespace Metal.NET;

public readonly struct MTLFunctionLogDebugLocation(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public nuint Column
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Column);
    }

    public NSString? FunctionName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogDebugLocationBindings.FunctionName);
            return ptr is not 0 ? new NSString(ptr) : default;
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
            return ptr is not 0 ? new NSURL(ptr) : default;
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
