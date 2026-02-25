namespace Metal.NET;

public class MTLFunctionLogDebugLocation(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionLogDebugLocation>
{
    public static MTLFunctionLogDebugLocation Null => Create(0, false);
    public static MTLFunctionLogDebugLocation Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public nuint Column
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Column);
    }

    public NSString FunctionName
    {
        get => GetProperty(ref field, MTLFunctionLogDebugLocationBindings.FunctionName);
    }

    public nuint Line
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Line);
    }

    public NSURL URL
    {
        get => GetProperty(ref field, MTLFunctionLogDebugLocationBindings.URL);
    }
}

file static class MTLFunctionLogDebugLocationBindings
{
    public static readonly Selector Column = "column";

    public static readonly Selector FunctionName = "functionName";

    public static readonly Selector Line = "line";

    public static readonly Selector URL = "URL";
}
