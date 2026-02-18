namespace Metal.NET;

public partial class MTLFunctionLogDebugLocation : NativeObject
{
    public MTLFunctionLogDebugLocation(nint nativePtr) : base(nativePtr)
    {
    }

    public NSURL? URL
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogDebugLocationSelector.URL);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint Column
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationSelector.Column);
    }

    public NSString? FunctionName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogDebugLocationSelector.FunctionName);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint Line
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationSelector.Line);
    }
}

file static class MTLFunctionLogDebugLocationSelector
{
    public static readonly Selector Column = Selector.Register("column");

    public static readonly Selector FunctionName = Selector.Register("functionName");

    public static readonly Selector Line = Selector.Register("line");

    public static readonly Selector URL = Selector.Register("URL");
}
