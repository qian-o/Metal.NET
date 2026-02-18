namespace Metal.NET;

public class MTLFunctionLogDebugLocation(nint nativePtr) : NativeObject(nativePtr)
{

    public nuint Column
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationSelector.Column);
    }

    public NSString? FunctionName
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogDebugLocationSelector.FunctionName));
    }

    public nuint Line
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationSelector.Line);
    }

    public NSURL? URL
    {
        get => GetNullableObject<NSURL>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionLogDebugLocationSelector.URL));
    }
}

file static class MTLFunctionLogDebugLocationSelector
{
    public static readonly Selector Column = Selector.Register("column");

    public static readonly Selector FunctionName = Selector.Register("functionName");

    public static readonly Selector Line = Selector.Register("line");

    public static readonly Selector URL = Selector.Register("URL");
}
