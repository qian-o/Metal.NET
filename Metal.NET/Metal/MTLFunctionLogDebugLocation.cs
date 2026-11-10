namespace Metal.NET;

public readonly struct MTLFunctionLogDebugLocation(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLFunctionLogDebugLocation value) => new(value.NativePtr);

    public MTLFunctionLogDebugLocation Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString FunctionName
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionLogDebugLocationBindings.FunctionName));
    }

    public NSURL Url
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionLogDebugLocationBindings.URL));
    }

    public nuint Line
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Line);
    }

    public nuint Column
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionLogDebugLocationBindings.Column);
    }
}

file static class MTLFunctionLogDebugLocationBindings
{
    public static readonly Selector Column = "column";

    public static readonly Selector FunctionName = "functionName";

    public static readonly Selector Line = "line";

    public static readonly Selector URL = "URL";
}
